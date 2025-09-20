using MongoDB.Bson;
using MongoDB.Driver;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoWinApp
{
    public partial class BulkMigrationMongoToOracle : Form
    {
        private IMongoDatabase database;

        public BulkMigrationMongoToOracle()
        {
            InitializeComponent();
            ApplyModernTheme();

            var names = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            MessageBox.Show(string.Join("\n", names));
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
                    Color.FromArgb(231, 76, 60),   // Bottom pink
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
        }

        private void ApplyModernTheme()
        {
            this.BackColor = Color.FromArgb(245, 215, 255);
            this.Font = new Font("Segoe UI", 10);
        }

        private void CheckProjectStatus_Replica_Load(object sender, EventArgs e)
        {
            this.Resize += (s, e2) =>
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

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new MongoClient("mongodb://JPC:Dbs4uX74GgNej9NG@10.63.119.116:27017/?authSource=admin");
                var database = client.GetDatabase("JPC_DATA");

                string mongoCollectionName = "NGO_PlanOffering";
                var collection = database.GetCollection<BsonDocument>(mongoCollectionName);

                progressBar1.Visible = true;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = (int)collection.CountDocuments(new BsonDocument()); // total docs
                progressBar1.Value = 0;

                string oracleConnStr = oracleConnStr = "User Id=epc;Password=rjiloc_23;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.63.57.162)(PORT=1521))(CONNECT_DATA=(SID=EPCREP)))";

                int batchSize = 5000; // can adjust based on memory
                int totalCount = 0;

                await Task.Run(() =>
                {
                    var itemCodes = new List<string>();
                    var itemTypes = new List<string>();
                    var name = new List<string>();
                    var offerType = new List<string>();
                    var billingType = new List<string>();
                    var category = new List<string>();
                    var price = new List<string>();
                    var geography = new List<string>();

                    using (var cursor = collection.Find(new BsonDocument()).ToCursor())
                    {
                        foreach (var doc in cursor.ToEnumerable())
                        {
                            itemCodes.Add(doc.Contains("ITEMCODE") ? doc["ITEMCODE"].ToString() : null);
                            itemTypes.Add(doc.Contains("ITEMTYPE") ? doc["ITEMTYPE"].ToString() : null);
                            name.Add(doc.Contains("NAME") ? doc["NAME"].ToString() : null);
                            offerType.Add(doc.Contains("OFFERTYPE") ? doc["OFFERTYPE"].ToString() : null);
                            billingType.Add(doc.Contains("BILLINGTYPE") ? doc["BILLINGTYPE"].ToString() : null);
                            category.Add(doc.Contains("CATEGORY") ? doc["CATEGORY"].ToString() : null);
                            price.Add(doc.Contains("PRICE") ? doc["PRICE"].ToString() : null);

                            string geo = doc.Contains("GEOGRAPHY") ? doc["GEOGRAPHY"].ToString() : null;
                            if (!string.IsNullOrEmpty(geo) && geo.Length > 100)
                                geo = geo.Substring(0, 100);
                            geography.Add(geo);

                            totalCount++;

                            if (totalCount % batchSize == 0)
                            {
                                InsertBatchToOracle(itemCodes, itemTypes, name, offerType, billingType, category, price, geography, oracleConnStr);
                                itemCodes.Clear(); itemTypes.Clear(); name.Clear();
                                offerType.Clear(); billingType.Clear(); category.Clear();
                                price.Clear(); geography.Clear();

                                // Update progress bar on UI thread
                                this.Invoke((Action)(() =>
                                {
                                    progressBar1.Value = Math.Min(totalCount, progressBar1.Maximum);
                                }));
                            }
                        }

                        // Insert remaining docs
                        if (itemCodes.Count > 0)
                        {
                            InsertBatchToOracle(itemCodes, itemTypes, name, offerType, billingType, category, price, geography, oracleConnStr);
                            this.Invoke((Action)(() =>
                            {
                                progressBar1.Value = totalCount;
                            }));
                        }
                    }
                });

                MessageBox.Show($"Inserted {totalCount} documents into Oracle ✅");
                progressBar1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                progressBar1.Visible = false;
            }
        }

        // Oracle insert method
        private void InsertBatchToOracle(
            List<string> itemCodes, List<string> itemTypes, List<string> name,
            List<string> offerType, List<string> billingType, List<string> category,
            List<string> price, List<string> geography, string oracleConnStr)
        {
            using (OracleConnection conn = new OracleConnection(oracleConnStr))
            {
                conn.Open();
                using (OracleCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO NGO_PLANOFFERING (ITEMCODE,ITEMTYPE,NAME,OFFERTYPE,BILLINGTYPE,CATEGORY,PRICE,GEOGRAPHY) " +
                                      "VALUES (:ITEMCODE, :ITEMTYPE, :NAME, :OFFERTYPE, :BILLINGTYPE, :CATEGORY, :PRICE, :GEOGRAPHY)";
                    cmd.ArrayBindCount = itemCodes.Count;

                    cmd.Parameters.Add(":ITEMCODE", OracleDbType.Varchar2, itemCodes.ToArray(), ParameterDirection.Input);
                    cmd.Parameters.Add(":ITEMTYPE", OracleDbType.Varchar2, itemTypes.ToArray(), ParameterDirection.Input);
                    cmd.Parameters.Add(":NAME", OracleDbType.Varchar2, name.ToArray(), ParameterDirection.Input);
                    cmd.Parameters.Add(":OFFERTYPE", OracleDbType.Varchar2, offerType.ToArray(), ParameterDirection.Input);
                    cmd.Parameters.Add(":BILLINGTYPE", OracleDbType.Varchar2, billingType.ToArray(), ParameterDirection.Input);
                    cmd.Parameters.Add(":CATEGORY", OracleDbType.Varchar2, category.ToArray(), ParameterDirection.Input);
                    cmd.Parameters.Add(":PRICE", OracleDbType.Varchar2, price.ToArray(), ParameterDirection.Input);
                    cmd.Parameters.Add(":GEOGRAPHY", OracleDbType.Varchar2, geography.ToArray(), ParameterDirection.Input);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}
