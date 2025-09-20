using DocumentFormat.OpenXml.Drawing.Charts;
using MongoDB.Bson;
using MongoDB.Driver;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MongoWinApp
{
    public partial class OptionForm : Form
    {
        public OptionForm()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Resize += (s, e) =>
            {
                if (this.WindowState != FormWindowState.Minimized)
                {
                    this.Invalidate();
                }
            };
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


        private string GetSelectedEnvironment()
        {
            return materialComboBox1.SelectedItem?.ToString() ?? "--select--";
        }

        private bool ValidateEnvironment()
        {
            string env = GetSelectedEnvironment();
            if (env == "--select--")
            {
                MessageBox.Show("Please select an execution environment.", "Environment Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btn_updateoperations_Click(object sender, EventArgs e)
        {
            if (!ValidateEnvironment()) return;

            string env = GetSelectedEnvironment();
            if (env == "JPC Replica")
            {
                NestedFormUpdate_Replica formUpdate = new NestedFormUpdate_Replica();
                formUpdate.FormClosed += (s, args) => this.Close();
                formUpdate.Show();
                this.Hide();
            }
            else if (env == "JPC Prod")
            {
                NestedFormUpdate_Prod formUpdate = new NestedFormUpdate_Prod();
                formUpdate.FormClosed += (s, args) => this.Close();
                formUpdate.Show();
                this.Hide();
            }
        }

        private void btn_deleteoperations_Click(object sender, EventArgs e)
        {
            if (!ValidateEnvironment()) return;

            string env = GetSelectedEnvironment();
            if (env == "JPC Replica")
            {
                NestedFormDelete_Replica formDelete = new NestedFormDelete_Replica();
                formDelete.FormClosed += (s, args) => this.Close();
                formDelete.Show();
                this.Hide();
            }
            else if (env == "JPC Prod")
            {
                NestedFormDelete_Prod formDelete = new NestedFormDelete_Prod();
                formDelete.FormClosed += (s, args) => this.Close();
                formDelete.Show();
                this.Hide();
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (!ValidateEnvironment()) return;

            string env = GetSelectedEnvironment();
            if (env == "JPC Replica")
            {
                MainFormUpdate_Replica formUpdate = new MainFormUpdate_Replica();
                formUpdate.FormClosed += (s, args) => this.Close();
                formUpdate.Show();
                this.Hide();
            }
            else if (env == "JPC Prod")
            {
                MainFormUpdate_Prod formUpdate = new MainFormUpdate_Prod();
                formUpdate.FormClosed += (s, args) => this.Close();
                formUpdate.Show();
                this.Hide();
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (!ValidateEnvironment()) return;

            string env = GetSelectedEnvironment();
            if (env == "JPC Replica")
            {
                MainFormDelete_Replica formUpdate = new MainFormDelete_Replica();
                formUpdate.FormClosed += (s, args) => this.Close();
                formUpdate.Show();
                this.Hide();
            }
            else if (env == "JPC Prod")
            {
                MainFormDelete_Prod formUpdate = new MainFormDelete_Prod();
                formUpdate.FormClosed += (s, args) => this.Close();
                formUpdate.Show();
                this.Hide();
            }
        }

        private void OptionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            if (!ValidateEnvironment()) return;

            string env = GetSelectedEnvironment();
            if (env == "JPC Replica")
            {
                CheckProjectStatus_Replica formStatus = new CheckProjectStatus_Replica();
                formStatus.FormClosed += (s, args) => this.Close();
                formStatus.Show();
                this.Hide();
            }
            else if (env == "JPC Prod")
            {
                CheckProjectStatus_Prod formStatusprod = new CheckProjectStatus_Prod();
                formStatusprod.FormClosed += (s, args) => this.Close();
                formStatusprod.Show();
                this.Hide();
            }
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            CompareType3 formcompareType3 = new CompareType3();
            formcompareType3.FormClosed += (s, args) => this.Close();
            formcompareType3.Show();
            this.Hide();
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            BulkMigration formBulkMigration = new BulkMigration();
            formBulkMigration.FormClosed += (s, args) => this.Close();
            formBulkMigration.Show();
            this.Hide();
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            BulkMigrationMongoToOracle formBulkMigrationMongoToOracle = new BulkMigrationMongoToOracle();
            formBulkMigrationMongoToOracle.FormClosed += (s, args) => this.Close();
            formBulkMigrationMongoToOracle.Show();
            this.Hide();
        }
    }
}
