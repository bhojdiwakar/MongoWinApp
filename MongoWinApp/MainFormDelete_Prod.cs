using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using MongoBson = MongoDB.Bson.Serialization;
using NewtonsoftJson = Newtonsoft.Json;

namespace MongoWinApp
{
    public partial class MainFormDelete_Prod : Form
    {
        private IMongoDatabase database;

        public MainFormDelete_Prod()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Size = new Size(1267, 682);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            ApplyModernTheme();

            var names = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            MessageBox.Show(string.Join("\n", names));

            var client = new MongoClient("mongodb://JPC:JiOjhs6giUI75jiL@10.137.54.98:27017/?authSource=admin");
            //database = client.GetDatabase("JPCOPS_TEST_DB");
            database = client.GetDatabase("JPC_DATA");

            comboBoxCollections.SelectedIndexChanged += comboBoxCollections_SelectedIndexChanged;
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

        private void btnLoadCollections_Click(object sender, EventArgs e)
        {
            var collections = database.ListCollectionNames().ToList();

            comboBoxCollections.Items.Clear();
            foreach (var name in collections)
            {
                comboBoxCollections.Items.Add(name);
            }

            MessageBox.Show("Collections loaded!");
        }

        void comboBoxCollections_SelectedIndexChanged(object? sender, EventArgs e)
        {
            string selectedCollection = comboBoxCollections.SelectedItem.ToString();

            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = "MongoWinApp.collections.json";

            string json;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            var dict = NewtonsoftJson.JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);


            comboBoxFields1.Items.Clear();


            if (dict != null && dict.ContainsKey(selectedCollection))
            {
                foreach (var field in dict[selectedCollection])
                {

                    comboBoxFields1.Items.Add(field);

                }
            }
            else
            {
                MessageBox.Show("No fields found for selected collection.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (comboBoxCollections.SelectedItem == null ||
       comboBoxFields1.SelectedItem == null ||
       string.IsNullOrWhiteSpace(txtBoxfield1.Text))
            {
                MessageBox.Show("Please select collection, filter field, and enter filter values.");
                return;
            }

            string collectionName = comboBoxCollections.SelectedItem.ToString().Trim();
            string filterField = comboBoxFields1.SelectedItem.ToString().Trim();
            string[] filterValues = txtBoxfield1.Text.Split(',')
                                                      .Select(v => v.Trim())
                                                      .Where(v => !string.IsNullOrEmpty(v))
                                                      .ToArray();

            if (filterValues.Length == 0)
            {
                MessageBox.Show("Please enter at least one filter value.");
                return;
            }

            var collection = database.GetCollection<BsonDocument>(collectionName);
            var filter = Builders<BsonDocument>.Filter.In(filterField, filterValues);

            long matchingCount = collection.CountDocuments(filter);

            if (matchingCount == 0)
            {
                MessageBox.Show("No documents match the given filter.");
                return;
            }

            var confirmResult = MessageBox.Show(
                $"This will permanently delete {matchingCount} document(s).\nDo you want to continue?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmResult != DialogResult.Yes)
            {
                MessageBox.Show("Delete operation cancelled.");
                return;
            }

            try
            {
                var result = collection.DeleteMany(filter);
                MessageBox.Show($"Delete complete.\nDeleted Count: {result.DeletedCount}");


                var logCollection = database.GetCollection<BsonDocument>("operation_logs");

                var logDocument = new BsonDocument
        {
            { "operation", "Delete-MainDocument"},
            { "collection", collectionName },
            { "filterField", filterField },
            { "filterValues", new BsonArray(filterValues) },
            { "deletedCount", result.DeletedCount },
            { "performedBy", Environment.UserName },
            { "machineName", Environment.MachineName },
            { "timestamp", BsonDateTime.Create(DateTime.UtcNow) }
        };

                logCollection.InsertOne(logDocument);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Delete failed:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainFormDelete_Prod_Load(object sender, EventArgs e)
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
    }
}
