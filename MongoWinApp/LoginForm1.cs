using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoWinApp
{
    public partial class LoginForm1 : Form
    {
        public LoginForm1()
        {
            InitializeComponent();
            //this.Size = new Size(1024, 768); // Or whatever fixed size you prefer
            //this.MaximumSize = this.Size;
            //this.MinimumSize = this.Size;
        }

        private void LoginForm1_Load(object sender, EventArgs e)
        {
           
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


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Hardcoded credentials
            const string validUsername = "admin";
            const string validPassword = "admin";

            if (username == validUsername && password == validPassword)
            {
                // Successful login
                this.Hide();
                OptionForm optionForm = new OptionForm();
                optionForm.FormClosed += (s, args) => this.Close();
                optionForm.Show();
            }
            else
            {
                // Failed login
                MessageBox.Show("Invalid username or password.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoginForm1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
