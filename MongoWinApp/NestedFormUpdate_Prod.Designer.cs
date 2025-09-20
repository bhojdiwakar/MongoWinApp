namespace MongoWinApp
{
    partial class NestedFormUpdate_Prod
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
            comboBoxFields = new ComboBox();
            comboBoxFields1 = new ComboBox();
            txtBoxfield = new TextBox();
            txtBoxfield1 = new TextBox();
            label1 = new Label();
            txtBoxfield2 = new TextBox();
            comboBoxFields2 = new ComboBox();
            btnUpdate = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnLoadCollections
            // 
            btnLoadCollections.Location = new Point(544, 128);
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
            comboBoxCollections.Location = new Point(363, 195);
            comboBoxCollections.Name = "comboBoxCollections";
            comboBoxCollections.Size = new Size(546, 33);
            comboBoxCollections.TabIndex = 1;
            // 
            // comboBoxFields
            // 
            comboBoxFields.FormattingEnabled = true;
            comboBoxFields.Location = new Point(288, 253);
            comboBoxFields.Name = "comboBoxFields";
            comboBoxFields.Size = new Size(546, 33);
            comboBoxFields.TabIndex = 2;
            // 
            // comboBoxFields1
            // 
            comboBoxFields1.FormattingEnabled = true;
            comboBoxFields1.Location = new Point(288, 311);
            comboBoxFields1.Name = "comboBoxFields1";
            comboBoxFields1.Size = new Size(546, 33);
            comboBoxFields1.TabIndex = 3;
            // 
            // txtBoxfield
            // 
            txtBoxfield.Location = new Point(863, 255);
            txtBoxfield.Name = "txtBoxfield";
            txtBoxfield.Size = new Size(272, 31);
            txtBoxfield.TabIndex = 4;
            // 
            // txtBoxfield1
            // 
            txtBoxfield1.Location = new Point(861, 311);
            txtBoxfield1.Name = "txtBoxfield1";
            txtBoxfield1.Size = new Size(272, 31);
            txtBoxfield1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 258);
            label1.Name = "label1";
            label1.Size = new Size(210, 25);
            label1.TabIndex = 6;
            label1.Text = "Select the field to update";
            // 
            // txtBoxfield2
            // 
            txtBoxfield2.Location = new Point(861, 365);
            txtBoxfield2.Name = "txtBoxfield2";
            txtBoxfield2.Size = new Size(272, 31);
            txtBoxfield2.TabIndex = 8;
            // 
            // comboBoxFields2
            // 
            comboBoxFields2.FormattingEnabled = true;
            comboBoxFields2.Location = new Point(288, 365);
            comboBoxFields2.Name = "comboBoxFields2";
            comboBoxFields2.Size = new Size(546, 33);
            comboBoxFields2.TabIndex = 7;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(544, 466);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(210, 34);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "UpdateRecords";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 317);
            label2.Name = "label2";
            label2.Size = new Size(149, 25);
            label2.TabIndex = 10;
            label2.Text = "Select ParentField";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 373);
            label3.Name = "label3";
            label3.Size = new Size(173, 25);
            label3.TabIndex = 11;
            label3.Text = "Select Array Element";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(180, 141, 219);
            label4.FlatStyle = FlatStyle.Popup;
            label4.Font = new Font("Algerian", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(0, 64, 0);
            label4.Location = new Point(533, 9);
            label4.Name = "label4";
            label4.Size = new Size(196, 45);
            label4.TabIndex = 18;
            label4.Text = "JPC Prod";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Purple_home_small;
            pictureBox2.Location = new Point(1136, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(107, 100);
            pictureBox2.TabIndex = 17;
            pictureBox2.TabStop = false;
            // 
            // NestedFormUpdate_Prod
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1245, 626);
            Controls.Add(label4);
            Controls.Add(pictureBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnUpdate);
            Controls.Add(txtBoxfield2);
            Controls.Add(comboBoxFields2);
            Controls.Add(label1);
            Controls.Add(txtBoxfield1);
            Controls.Add(txtBoxfield);
            Controls.Add(comboBoxFields1);
            Controls.Add(comboBoxFields);
            Controls.Add(comboBoxCollections);
            Controls.Add(btnLoadCollections);
            Name = "NestedFormUpdate_Prod";
            Text = "MainFormUpdate_Prod";
            Load += MainFormUpdate_Prod_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoadCollections;
        private ComboBox comboBoxCollections;
        private ComboBox comboBoxFields;
        private ComboBox comboBoxFields1;
        private TextBox txtBoxfield;
        private TextBox txtBoxfield1;
        private Label label1;
        private TextBox txtBoxfield2;
        private ComboBox comboBoxFields2;
        private Button btnUpdate;
        private Label label2;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox2;
    }
}