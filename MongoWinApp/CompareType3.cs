using ClosedXML.Excel;  // You can remove if not needed now
using ExcelDataReader; 
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
using System.Text;
using System.Windows.Forms;
// 👇 Alias to fix ambiguous Color reference
using DrawingColor = System.Drawing.Color;
using MongoBson = MongoDB.Bson.Serialization;
using NewtonsoftJson = Newtonsoft.Json;

namespace MongoWinApp
{
    public partial class CompareType3 : Form
    {
        private IMongoDatabase database;

        public CompareType3()
        {
            InitializeComponent();

            InitializeGrid();
            ApplyModernTheme();

            var names = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            MessageBox.Show(string.Join("\n", names));
        }

        private void InitializeGrid()
        {
            dataGridView1.Columns.Add("SheetName", "Sheet Name");
            dataGridView1.Columns.Add("File1Rows", "Replica Count");
            dataGridView1.Columns.Add("File2Rows", "Prod Count");

            dataGridView1.Columns["SheetName"].Width = 600;
            dataGridView1.Columns["File1Rows"].Width = 200;
            dataGridView1.Columns["File2Rows"].Width = 200;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            Rectangle rect = this.ClientRectangle;

            if (rect.Width > 0 && rect.Height > 0)
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    rect,
                    DrawingColor.FromArgb(146, 84, 208),  // Top purple
                    DrawingColor.FromArgb(231, 76, 60),   // Bottom pinkish
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
        }

        private void ApplyModernTheme()
        {
            this.BackColor = DrawingColor.FromArgb(245, 215, 255);
            this.Font = new Font("Segoe UI", 10);

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackColor = DrawingColor.FromArgb(0, 120, 215); // Fluent blue
                    btn.ForeColor = DrawingColor.White;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
                else if (ctrl is ComboBox || ctrl is TextBox)
                {
                    ctrl.BackColor = DrawingColor.White;
                    ctrl.ForeColor = DrawingColor.Black;
                    ctrl.Font = new Font("Segoe UI", 10);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var optionForm = new OptionForm();
            optionForm.Show();
            this.Hide();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xlsx;*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                materialTextBox21.Text = ofd.FileName;
            }
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xlsx;*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                materialTextBox22.Text = ofd.FileName;
            }
        }

        private void Btn_Compare_Click(object sender, EventArgs e)
        {
            string file1 = materialTextBox21.Text;
            string file2 = materialTextBox22.Text;

            if (string.IsNullOrWhiteSpace(file1) || string.IsNullOrWhiteSpace(file2))
            {
                MessageBox.Show("Please select both Excel files.");
                return;
            }

            dataGridView1.Rows.Clear();

            var rows1 = GetSheetRowCounts_Stream(file1);
            var rows2 = GetSheetRowCounts_Stream(file2);

            var allSheetNames = new HashSet<string>(rows1.Keys);
            allSheetNames.UnionWith(rows2.Keys);

            foreach (var sheetName in allSheetNames)
            {
                rows1.TryGetValue(sheetName, out int count1);
                rows2.TryGetValue(sheetName, out int count2);
                int rowIndex = dataGridView1.Rows.Add(sheetName, count1, count2);

                if (count1 != count2)
                {
                    dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = DrawingColor.Red;
                    dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = DrawingColor.White;
                }
            }
            dataGridView1.Visible = true;
        }

        // ✅ Streaming version: handles heavy Excel files without memory crash
        private Dictionary<string, int> GetSheetRowCounts_Stream(string filePath)
        {
            var dict = new Dictionary<string, int>();

            if (string.IsNullOrWhiteSpace(filePath) || Path.GetExtension(filePath) == "")
            {
                MessageBox.Show("Invalid file selected. Please choose a valid Excel file.");
                return dict;
            }

            try
            {
                System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var reader = ExcelReaderFactory.CreateReader(stream);

                do
                {
                    int rowCount = 0;
                    while (reader.Read())
                    {
                        rowCount++;
                    }

                    dict[reader.Name] = rowCount;

                } while (reader.NextResult()); // move to next sheet
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading Excel file: {ex.Message}");
            }

            return dict;
        }

        private void CompareType3_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }
    }
}
