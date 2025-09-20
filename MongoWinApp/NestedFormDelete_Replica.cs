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
    public partial class NestedFormDelete_Replica : Form
    {
        private IMongoDatabase database;

        public NestedFormDelete_Replica()
        {
            InitializeComponent();
           
            ApplyModernTheme();

            var names = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            MessageBox.Show(string.Join("\n", names));

            var client = new MongoClient("mongodb://JPC:Dbs4uX74GgNej9NG@10.63.119.116:27017/?authSource=admin");
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
            comboBoxFields2.Items.Clear();

            if (dict != null && dict.ContainsKey(selectedCollection))
            {
                foreach (var field in dict[selectedCollection])
                {

                    comboBoxFields1.Items.Add(field);
                    comboBoxFields2.Items.Add(field);
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
       comboBoxFields2.SelectedItem == null)
            {
                MessageBox.Show("Please select all required fields.");
                return;
            }

            string collectionName = comboBoxCollections.SelectedItem.ToString();
            string parentFilterField = comboBoxFields1.SelectedItem.ToString(); // e.g., "id"
            string[] parentIds = txtBoxfield1.Text.Split(',').Select(v => v.Trim()).ToArray();

            string fullArrayFieldPath = comboBoxFields2.SelectedItem.ToString(); // e.g., "geographicLocationToPlanOfferingMapping.item.id"
            string[] elementIdsToDelete = txtBoxfield2.Text.Split(',').Select(v => v.Trim()).ToArray();

            // Extract array path and field name
            int lastDotIndex = fullArrayFieldPath.LastIndexOf(".");
            if (lastDotIndex < 0)
            {
                MessageBox.Show("Invalid array field path.");
                return;
            }

            string arrayFieldPath = fullArrayFieldPath.Substring(0, lastDotIndex);  // e.g., "geographicLocationToPlanOfferingMapping.item"
            string elementMatchField = fullArrayFieldPath.Substring(lastDotIndex + 1); // e.g., "id"

            var collection = database.GetCollection<BsonDocument>(collectionName);

            var filter = Builders<BsonDocument>.Filter.In(parentFilterField, parentIds);
            var matchingCount = collection.CountDocuments(filter);

            if (matchingCount == 0)
            {
                MessageBox.Show("No documents match the given filter.");
                return;
            }

            var confirmResult = MessageBox.Show(
                $"This will delete nested array elements in {matchingCount} document(s). Proceed?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmResult != DialogResult.Yes)
            {
                MessageBox.Show("Delete operation cancelled.");
                return;
            }

            var pullFilter = Builders<BsonDocument>.Update.PullFilter(
                arrayFieldPath,
                Builders<BsonDocument>.Filter.In(elementMatchField, elementIdsToDelete)
            );

            var result = collection.UpdateMany(filter, pullFilter);

            MessageBox.Show($"Delete complete.\nMatched: {result.MatchedCount}\nModified: {result.ModifiedCount}");

            var logCollection = database.GetCollection<BsonDocument>("operation_logs");

            var logDocument = new BsonDocument
        {
            { "operation", "Delete-NestedArray"},
            { "collection", collectionName },
            { "filterField", parentFilterField },
            { "filterValues", new BsonArray(parentIds) },
            { "arrayFieldPath", arrayFieldPath },
            { "matchFieldInArray", elementMatchField },
            { "deletedValues", new BsonArray(elementIdsToDelete) },
            { "matchedCount", result.MatchedCount },
            { "modifiedCount", result.ModifiedCount },
            { "performedBy", Environment.UserName },
            { "machineName", Environment.MachineName },
            { "timestamp", BsonDateTime.Create(DateTime.UtcNow) }
        };

            logCollection.InsertOne(logDocument);

        }

    

        private void MainFormDelete_Replica_Load(object sender, EventArgs e)
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
