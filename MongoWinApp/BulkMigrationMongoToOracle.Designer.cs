namespace MongoWinApp
{
    partial class BulkMigrationMongoToOracle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label3 = new Label();
            pictureBox2 = new PictureBox();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            progressBar1 = new ProgressBar();
            labelProgress = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(180, 141, 219);
            label3.FlatStyle = FlatStyle.Popup;
            label3.Font = new Font("Algerian", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 64, 0);
            label3.Location = new Point(295, 2);
            label3.Name = "label3";
            label3.Size = new Size(776, 45);
            label3.TabIndex = 16;
            label3.Text = "EPC Bulk Migration Mongo To Oracle";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Purple_home_small;
            pictureBox2.Location = new Point(1135, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(107, 100);
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // materialButton1
            // 
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(568, 102);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(150, 36);
            materialButton1.TabIndex = 20;
            materialButton1.Text = "Start Migration";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(168, 190);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(965, 34);
            progressBar1.TabIndex = 21;
            // 
            // labelProgress
            // 
            labelProgress.AutoSize = true;
            labelProgress.Location = new Point(590, 286);
            labelProgress.Name = "labelProgress";
            labelProgress.Size = new Size(0, 25);
            labelProgress.TabIndex = 22;
            // 
            // BulkMigrationMongoToOracle
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1245, 626);
            Controls.Add(labelProgress);
            Controls.Add(progressBar1);
            Controls.Add(materialButton1);
            Controls.Add(label3);
            Controls.Add(pictureBox2);
            Name = "BulkMigrationMongoToOracle";
            Text = "BulkMigration";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private PictureBox pictureBox2;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private ProgressBar progressBar1;
        private Label labelProgress;
    }
}