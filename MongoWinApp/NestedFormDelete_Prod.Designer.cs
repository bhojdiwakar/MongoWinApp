namespace MongoWinApp
{
    partial class NestedFormDelete_Prod
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
            txtBoxfield2 = new TextBox();
            comboBoxFields2 = new ComboBox();
            btnDelete = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnLoadCollections
            // 
            btnLoadCollections.Location = new Point(544, 185);
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
            comboBoxCollections.Location = new Point(395, 252);
            comboBoxCollections.Name = "comboBoxCollections";
            comboBoxCollections.Size = new Size(546, 33);
            comboBoxCollections.TabIndex = 1;
            // 
            // comboBoxFields1
            // 
            comboBoxFields1.FormattingEnabled = true;
            comboBoxFields1.Location = new Point(327, 327);
            comboBoxFields1.Name = "comboBoxFields1";
            comboBoxFields1.Size = new Size(546, 33);
            comboBoxFields1.TabIndex = 3;
            // 
            // txtBoxfield1
            // 
            txtBoxfield1.Location = new Point(900, 327);
            txtBoxfield1.Name = "txtBoxfield1";
            txtBoxfield1.Size = new Size(272, 31);
            txtBoxfield1.TabIndex = 5;
            // 
            // txtBoxfield2
            // 
            txtBoxfield2.Location = new Point(900, 381);
            txtBoxfield2.Name = "txtBoxfield2";
            txtBoxfield2.Size = new Size(272, 31);
            txtBoxfield2.TabIndex = 8;
            // 
            // comboBoxFields2
            // 
            comboBoxFields2.FormattingEnabled = true;
            comboBoxFields2.Location = new Point(327, 381);
            comboBoxFields2.Name = "comboBoxFields2";
            comboBoxFields2.Size = new Size(546, 33);
            comboBoxFields2.TabIndex = 7;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(544, 496);
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
            label2.Location = new Point(39, 333);
            label2.Name = "label2";
            label2.Size = new Size(149, 25);
            label2.TabIndex = 10;
            label2.Text = "Select ParentField";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 386);
            label3.Name = "label3";
            label3.Size = new Size(284, 25);
            label3.TabIndex = 11;
            label3.Text = "Select Array Element to be deleted";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(180, 141, 219);
            label4.FlatStyle = FlatStyle.Popup;
            label4.Font = new Font("Algerian", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(0, 64, 0);
            label4.Location = new Point(525, 0);
            label4.Name = "label4";
            label4.Size = new Size(196, 45);
            label4.TabIndex = 20;
            label4.Text = "JPC Prod";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Purple_home_small;
            pictureBox2.Location = new Point(1137, -2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(107, 100);
            pictureBox2.TabIndex = 19;
            pictureBox2.TabStop = false;
            // 
            // NestedFormDelete_Prod
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1245, 626);
            Controls.Add(label4);
            Controls.Add(pictureBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnDelete);
            Controls.Add(txtBoxfield2);
            Controls.Add(comboBoxFields2);
            Controls.Add(txtBoxfield1);
            Controls.Add(comboBoxFields1);
            Controls.Add(comboBoxCollections);
            Controls.Add(btnLoadCollections);
            Name = "NestedFormDelete_Prod";
            Text = "MainFormDelete_Prod";
            Load += MainFormDelete_Prod_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoadCollections;
        private ComboBox comboBoxCollections;
        private ComboBox comboBoxFields1;
        private TextBox txtBoxfield1;
        private TextBox txtBoxfield2;
        private ComboBox comboBoxFields2;
        private Button btnDelete;
        private Label label2;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox2;
    }
}