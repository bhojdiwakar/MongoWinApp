using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Data;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MongoBson = MongoDB.Bson.Serialization;
using NewtonsoftJson = Newtonsoft.Json;

namespace MongoWinApp
{
    public partial class BulkMigration : Form
    {
        private IMongoDatabase database;

        public BulkMigration()
        {
            InitializeComponent();
          
            //this.AutoScaleMode = AutoScaleMode.Font;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //this.MaximizeBox = false;
            //this.Size = new Size(1267, 682);
            //this.MaximumSize = this.Size;
            //this.MinimumSize = this.Size;

            ApplyModernTheme(); // 👈 Call the theme here

            var names = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            MessageBox.Show(string.Join("\n", names));

            //var client = new MongoClient("mongodb://JPC:Dbs4uX74GgNej9NG@10.63.119.116:27017/?authSource=admin");
            //database = client.GetDatabase("JPCOPS_TEST_DB");
            ////database = client.GetDatabase("JPC_DATA");


        }

       
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            Rectangle rect = this.ClientRectangle;

            if (rect.Width > 0 && rect.Height > 0)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    rect,
                    Color.FromArgb(146, 84, 208),  // Top purple
                    Color.FromArgb(231, 76, 60),   // Bottom pink-pinkish
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
        }


        private void ApplyModernTheme()
        {
            this.BackColor = Color.FromArgb(245, 215, 255);
            //this.BackColor = Color.FromArgb(255, 222, 0);
            this.Font = new Font("Segoe UI", 10);
                 
        }



        private void CheckProjectStatus_Replica_Load(object sender, EventArgs e)
        {
            this.Resize += (s, e) =>
            {
                if (this.WindowState != FormWindowState.Minimized)
                {
                    this.Invalidate();
                }
            };
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var optionForm = new OptionForm();
            optionForm.Show();
            this.Hide();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //Replica
                //string oracleConnStr = "User Id=epc;Password=rjiloc_23;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.63.57.162)(PORT=1521))(CONNECT_DATA=(SID=EPCREP)))";

                //Prod
                string oracleConnStr = "User Id=epc;Password=epc;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.136.112.130)(PORT=1521))(CONNECT_DATA=(SID=EPCPROD)))";

                var client = new MongoClient("mongodb://JPC:Dbs4uX74GgNej9NG@10.63.119.116:27017/?authSource=admin");
                var db = client.GetDatabase("JPCOPS_TEST_DB");
                var collection = db.GetCollection<BsonDocument>("CWMESSAGELOG_PROD");

                using (var oracleConn = new OracleConnection(oracleConnStr))
                {
                    oracleConn.Open();

                    // 1️⃣ Get row count for progress bar
                    int totalRows = 0;
                    using (var countCmd = new OracleCommand("SELECT COUNT(*) FROM cwmessagelog WHERE operation ='epcImplementation:IssueProductData/IssueProductData' and DBMS_LOB.getlength(SEND_DATA) / (1024 * 1024) <= '15.94353008270263671875'", oracleConn))
                    {
                        totalRows = Convert.ToInt32(countCmd.ExecuteScalar());
                    }

                    progressBar1.Value = 0;
                    progressBar1.Maximum = totalRows;
                    labelProgress.Text = "0% completed";

                    // 2️⃣ Fetch rows in a streaming fashion
                    string query = "SELECT msgid, send_data FROM cwmessagelog WHERE operation ='epcImplementation:IssueProductData/IssueProductData' and DBMS_LOB.getlength(SEND_DATA) / (1024 * 1024) <= '15.94353008270263671875'";
                    using (var cmd = new OracleCommand(query, oracleConn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        int processedRows = 0;

                        while (reader.Read())
                        {
                            // ✅ msgid (safe as string)
                            string msgId = reader.GetValue(0).ToString();

                            // ✅ send_data (BLOB / CLOB / VARCHAR2 safe)
                            string xmlContent = "";
                            if (!reader.IsDBNull(1))
                            {
                                object rawValue = reader.GetValue(1);

                                switch (rawValue)
                                {
                                    case OracleBlob blob:
                                        xmlContent = Encoding.UTF8.GetString(blob.Value);
                                        break;

                                    case OracleClob clob:
                                        xmlContent = clob.Value;
                                        break;

                                    case byte[] bytes:
                                        xmlContent = Encoding.UTF8.GetString(bytes);
                                        break;

                                    default:
                                        xmlContent = rawValue.ToString();
                                        break;
                                }
                            }

                            // ✅ Insert into MongoDB
                            var doc = new BsonDocument
                    {
                        { "msgid", msgId },
                        { "xml_content", xmlContent }
                    };
                            collection.InsertOne(doc);

                            // 3️⃣ Update progress
                            processedRows++;
                            if (processedRows <= progressBar1.Maximum)
                                progressBar1.Value = processedRows;

                            int percent = (int)((processedRows / (double)totalRows) * 100);
                            labelProgress.Text = percent + "% completed";

                            Application.DoEvents(); // keep UI responsive
                        }
                    }
                }

                labelProgress.Text = "Migration completed ✔";
                MessageBox.Show("Streaming migration completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during migration:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}