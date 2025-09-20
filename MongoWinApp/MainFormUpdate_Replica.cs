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
    public partial class MainFormUpdate_Replica : Form
    {
        private IMongoDatabase database;

        public MainFormUpdate_Replica()
        {
            InitializeComponent();
            
            ApplyModernTheme();

            var names = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            MessageBox.Show(string.Join("\n", names));


            var client = new MongoClient("mongodb://JPC:Dbs4uX74GgNej9NG@10.63.119.116:27017/?authSource=admin");
            //test db
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

            comboBoxFields.Items.Clear();
            comboBoxFields1.Items.Clear();


            if (dict != null && dict.ContainsKey(selectedCollection))
            {
                foreach (var field in dict[selectedCollection])
                {
                    comboBoxFields.Items.Add(field);
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
        comboBoxFields.SelectedItem == null ||
        comboBoxFields1.SelectedItem == null)
            {
                MessageBox.Show("Please select all required fields.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBoxfield.Text) || string.IsNullOrWhiteSpace(txtBoxfield1.Text))
            {
                MessageBox.Show("Please fill in both value and filter inputs.");
                return;
            }

            // Gather user inputs
            string collectionName = comboBoxCollections.SelectedItem.ToString().Trim();
            string updateField = comboBoxFields.SelectedItem.ToString().Trim();      // Field to update
            string filterField = comboBoxFields1.SelectedItem.ToString().Trim();     // Field to filter on
            string updateValue = txtBoxfield.Text.Trim();                            // New value
            string[] filterValues = txtBoxfield1.Text.Split(',').Select(v => v.Trim()).ToArray(); // Filter values

            var collection = database.GetCollection<BsonDocument>(collectionName);
            var filter = Builders<BsonDocument>.Filter.In(filterField, filterValues);
            var matchingCount = collection.CountDocuments(filter);

            if (matchingCount == 0)
            {
                MessageBox.Show("No documents match the given filter.");
                return;
            }

            var confirmResult = MessageBox.Show(
                $"This will update {matchingCount} document(s).\nProceed?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmResult != DialogResult.Yes)
            {
                MessageBox.Show("Update cancelled.");
                return;
            }

            // Build update document
            var update = Builders<BsonDocument>.Update.Set(updateField, updateValue);

            try
            {
                var result = collection.UpdateMany(filter, update);
                MessageBox.Show($"Update complete.\nModified Count: {result.ModifiedCount}");

                var logCollection = database.GetCollection<BsonDocument>("operation_logs");

                var logDocument = new BsonDocument
        {
            { "operation", "Update-MainDocument" },
            { "collection", collectionName },
            { "filterField", filterField },
            { "filterValues", new BsonArray(filterValues) },
            { "fieldUpdated", updateField },
            { "newValue", updateValue },
            { "modifiedCount", result.ModifiedCount },
            { "performedBy", Environment.UserName },
            { "machineName", Environment.MachineName },
            { "timestamp", BsonDateTime.Create(DateTime.UtcNow) }
        };

                logCollection.InsertOne(logDocument);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void MainFormUpdate_Replica_Load(object sender, EventArgs e)
        {
            this.Resize += (s, e) =>
            {
                if (this.WindowState != FormWindowState.Minimized)
                {
                    this.Invalidate();
                }
            };
        }


        private void MainFormUpdate_Replica_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var optionForm = new OptionForm();
            optionForm.Show();
            this.Hide();
        }

    }
}
