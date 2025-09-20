namespace MongoWinApp
{
    partial class MainFormDelete_Replica
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
            btnLoadCollections = new Button();
            comboBoxCollections = new ComboBox();
            comboBoxFields1 = new ComboBox();
            txtBoxfield1 = new TextBox();
            btnDelete = new Button();
            label2 = new Label();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnLoadCollections
            // 
            btnLoadCollections.Location = new Point(549, 182);
            btnLoadCollections.Name = "btnLoadCollections";
            btnLoadCollections.Size = new Size(220, 34);
            btnLoadCollections.TabIndex = 0;
            btnLoadCollections.Text = "Load Collections";
            btnLoadCollections.UseVisualStyleBackColor = true;
            btnLoadCollections.Click += btnLoadCollections_Click;
            // 
            // comboBoxCollections
            // 
            comboBoxCollections.FormattingEnabled = true;
            comboBoxCollections.Location = new Point(395, 257);
            comboBoxCollections.Name = "comboBoxCollections";
            comboBoxCollections.Size = new Size(546, 33);
            comboBoxCollections.TabIndex = 1;
            // 
            // comboBoxFields1
            // 
            comboBoxFields1.FormattingEnabled = true;
            comboBoxFields1.Location = new Point(353, 332);
            comboBoxFields1.Name = "comboBoxFields1";
            comboBoxFields1.Size = new Size(546, 33);
            comboBoxFields1.TabIndex = 3;
            // 
            // txtBoxfield1
            // 
            txtBoxfield1.Location = new Point(926, 332);
            txtBoxfield1.Name = "txtBoxfield1";
            txtBoxfield1.Size = new Size(272, 31);
            txtBoxfield1.TabIndex = 5;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(554, 445);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(210, 34);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "DeleteRecords";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnUpdate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 338);
            label2.Name = "label2";
            label2.Size = new Size(299, 25);
            label2.TabIndex = 10;
            label2.Text = "Select main document to be deleted";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(180, 141, 219);
            label3.FlatStyle = FlatStyle.Popup;
            label3.Font = new Font("Algerian", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 64, 0);
            label3.Location = new Point(515, 12);
            label3.Name = "label3";
            label3.Size = new Size(259, 45);
            label3.TabIndex = 16;
            label3.Text = "JPC Replica";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Purple_home_small;
            pictureBox2.Location = new Point(1137, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(107, 100);
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // MainFormDelete_Replica
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1245, 626);
            Controls.Add(label3);
            Controls.Add(pictureBox2);
            Controls.Add(label2);
            Controls.Add(btnDelete);
            Controls.Add(txtBoxfield1);
            Controls.Add(comboBoxFields1);
            Controls.Add(comboBoxCollections);
            Controls.Add(btnLoadCollections);
            Name = "MainFormDelete_Replica";
            Text = "MainFormDelete_Replica";
            Load += MainFormDelete_Replica_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoadCollections;
        private ComboBox comboBoxCollections;
        private ComboBox comboBoxFields1;
        private TextBox txtBoxfield1;
        private Button btnDelete;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox2;
    }
}