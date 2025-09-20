using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using MongoBson = MongoDB.Bson.Serialization;
using NewtonsoftJson = Newtonsoft.Json;

namespace MongoWinApp
{
    public partial class CheckProjectStatus_Replica : Form
    {
        private IMongoDatabase database;

        public CheckProjectStatus_Replica()
        {
            InitializeComponent();
            dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete;

            ApplyModernTheme();

            var names = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            MessageBox.Show(string.Join("\n", names));

        }

        private void DataGridView1_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                var cell = row.Cells["Response"];
                if (cell?.Value != null)
                {
                    string status = cell.Value.ToString();
                    if (status == "SUCCESS")
                    {
                        cell.Style.BackColor = Color.Green;
                    }
                    else if (status == "FAILURE")
                    {
                        cell.Style.BackColor = Color.Red;
                    }
                    else if (status == "" || status == "NO RESPONSE")
                    {
                        cell.Style.BackColor = Color.Orange;

                        if (status == "")
                        {
                            cell.Value = "NO RESPONSE";
                        }
                    }
                    else
                    {
                        cell.Style.BackColor = Color.LightGray;
                    }

                    cell.Style.ForeColor = Color.White;
                }
            }

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

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackColor = Color.FromArgb(0, 120, 215); // Fluent blue
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
                else if (ctrl is ComboBox || ctrl is TextBox)
                {
                    ctrl.BackColor = Color.White;
                    ctrl.ForeColor = Color.Black;
                    ctrl.Font = new Font("Segoe UI", 10);
                }
            }
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
            string projectCode = materialTextBox1.Text.Trim();


            var client = new MongoClient("mongodb://JPC:Dbs4uX74GgNej9NG@10.63.119.116:27017/?authSource=admin");
            var db = client.GetDatabase("JPC_DATA");
            var collection = db.GetCollection<BsonDocument>("JPC_SyncResponse");
           

            var pipeline = new[]
            {
                new BsonDocument("$match", new BsonDocument("synchedProjectCodes",
                new BsonDocument("$regex", $"\\b{projectCode}\\b").Add("$options", "i"))),
                new BsonDocument("$sort", new BsonDocument("correlationId", -1)),
                new BsonDocument("$group", new BsonDocument
                 {
                    { "_id", "$systemName" },
                    { "status", new BsonDocument("$first", "$status") }
                 })
            };

            //Run aggregation
            var result = collection.Aggregate<BsonDocument>(pipeline).ToList();

            //Process results (statusDict logic)
            Dictionary<string, string> statusDict = new Dictionary<string, string>();

            foreach (var doc in result)
            {
                string systemName = doc["_id"].AsString;
                string status = (!doc.Contains("status") || doc["status"].IsBsonNull)
                    ? "No Response"
                    : doc["status"].AsString;

                statusDict[systemName] = status;
            }

            //Bind to grid
            var systems = new[] { "Campaign_Fulfillment_Platform", "CC", "CI_IR2", "CI_TR2", "CI_TR4", "CI_TR5", "CI_TR6", "CI_TRC", "CMP", "CRM", "EBPP", "EDIF", "EDIF2", "Ent_EBPP", "Enterprise_DKYC", "EntJioOC", "EntWebSelfCare", "EntWebSelfCareMobility", "eRecharge", "ERECHARGE_SOUTHWEST", "ERECHARGE_TPA", "ERECHARGE_PA_NOINVOICE", "ERECHARGESubscriberPOS", "FTTHCreateJioOC", "FTTHDeleteJioOC", "FTTHJioOC", "Home_EBPP", "ICM", "IoT_JEP", "IoT_JSMS", "IoT_OTT_JSMS", "IoTJioOC", "JAFUBRJioOC", "JCMS", "JCP", "JEP", "JioCareCRM", "JioCloud", "JioCSEVABot", "JioFM", "JioICM", "JioSafe", "JioSEDig", "JioSEEnt", "JioSEFttx", "JioSEVas", "JioTV", "JRCS_01", "JSMS", "MediaeRecharge", "MobCreateJioOCNorth", "MobCreateJioOCWest", "MobDelJioOCKL", "MobDelJioOCNorth", "MobDelJoOCWest", "MyJio", "MyJio_JioPhone", "OCENT", "OCMOBMUCR", "OCMOBMUDEL", "ODUJioOC", "OTTMKTPL", "QA2JRCS", "RETLARP417", "RPOS", "SE", "SEVAS", "WebSelfCare" };
            var table = new DataTable();
            table.Columns.Add("SystemName");
            table.Columns.Add("Response");

            foreach (var sys in systems)
            {
                string status = statusDict.ContainsKey(sys) ? statusDict[sys] : "NOT SYNCED";
                table.Rows.Add(sys, status);
            }

            dataGridView1.DataSource = table;

        }    
    }
}