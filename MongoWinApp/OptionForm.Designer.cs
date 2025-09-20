namespace MongoWinApp
{
    partial class OptionForm
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
            btn_updateoperations = new MaterialSkin.Controls.MaterialButton();
            btn_deleteoperations = new MaterialSkin.Controls.MaterialButton();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            materialButton2 = new MaterialSkin.Controls.MaterialButton();
            materialComboBox1 = new MaterialSkin.Controls.MaterialComboBox();
            label1 = new Label();
            materialButton3 = new MaterialSkin.Controls.MaterialButton();
            materialButton4 = new MaterialSkin.Controls.MaterialButton();
            materialButton5 = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // btn_updateoperations
            // 
            btn_updateoperations.AutoSize = false;
            btn_updateoperations.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_updateoperations.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_updateoperations.Depth = 0;
            btn_updateoperations.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_updateoperations.HighEmphasis = true;
            btn_updateoperations.Icon = null;
            btn_updateoperations.Location = new Point(338, 219);
            btn_updateoperations.Margin = new Padding(5, 7, 5, 7);
            btn_updateoperations.MouseState = MaterialSkin.MouseState.HOVER;
            btn_updateoperations.Name = "btn_updateoperations";
            btn_updateoperations.NoAccentTextColor = Color.Empty;
            btn_updateoperations.Size = new Size(278, 84);
            btn_updateoperations.TabIndex = 0;
            btn_updateoperations.Text = "Update Operations in nested array";
            btn_updateoperations.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_updateoperations.UseAccentColor = false;
            btn_updateoperations.UseVisualStyleBackColor = true;
            btn_updateoperations.Click += btn_updateoperations_Click;
            // 
            // btn_deleteoperations
            // 
            btn_deleteoperations.AutoSize = false;
            btn_deleteoperations.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_deleteoperations.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_deleteoperations.Depth = 0;
            btn_deleteoperations.HighEmphasis = true;
            btn_deleteoperations.Icon = null;
            btn_deleteoperations.Location = new Point(338, 331);
            btn_deleteoperations.Margin = new Padding(5, 7, 5, 7);
            btn_deleteoperations.MouseState = MaterialSkin.MouseState.HOVER;
            btn_deleteoperations.Name = "btn_deleteoperations";
            btn_deleteoperations.NoAccentTextColor = Color.Empty;
            btn_deleteoperations.Size = new Size(278, 84);
            btn_deleteoperations.TabIndex = 1;
            btn_deleteoperations.Text = "Delete Operations in nested array";
            btn_deleteoperations.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_deleteoperations.UseAccentColor = false;
            btn_deleteoperations.UseVisualStyleBackColor = true;
            btn_deleteoperations.Click += btn_deleteoperations_Click;
            // 
            // materialButton1
            // 
            materialButton1.AutoSize = false;
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(28, 219);
            materialButton1.Margin = new Padding(5, 7, 5, 7);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(278, 84);
            materialButton1.TabIndex = 2;
            materialButton1.Text = "Update Operations in main document";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click;
            // 
            // materialButton2
            // 
            materialButton2.AutoSize = false;
            materialButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton2.Depth = 0;
            materialButton2.HighEmphasis = true;
            materialButton2.Icon = null;
            materialButton2.Location = new Point(28, 331);
            materialButton2.Margin = new Padding(5, 7, 5, 7);
            materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton2.Name = "materialButton2";
            materialButton2.NoAccentTextColor = Color.Empty;
            materialButton2.Size = new Size(278, 84);
            materialButton2.TabIndex = 3;
            materialButton2.Text = "Delete Operations in main document";
            materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton2.UseAccentColor = false;
            materialButton2.UseVisualStyleBackColor = true;
            materialButton2.Click += materialButton2_Click;
            // 
            // materialComboBox1
            // 
            materialComboBox1.AutoResize = false;
            materialComboBox1.BackColor = Color.FromArgb(255, 255, 255);
            materialComboBox1.Depth = 0;
            materialComboBox1.DrawMode = DrawMode.OwnerDrawVariable;
            materialComboBox1.DropDownHeight = 174;
            materialComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox1.DropDownWidth = 121;
            materialComboBox1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialComboBox1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialComboBox1.FormattingEnabled = true;
            materialComboBox1.IntegralHeight = false;
            materialComboBox1.ItemHeight = 43;
            materialComboBox1.Items.AddRange(new object[] { "--select--", "JPC Replica", "JPC Prod" });
            materialComboBox1.Location = new Point(352, 96);
            materialComboBox1.MaxDropDownItems = 4;
            materialComboBox1.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox1.Name = "materialComboBox1";
            materialComboBox1.Size = new Size(182, 49);
            materialComboBox1.StartIndex = 0;
            materialComboBox1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(28, 106);
            label1.Name = "label1";
            label1.Size = new Size(278, 28);
            label1.TabIndex = 5;
            label1.Text = "Select Excecution Environment";
            // 
            // materialButton3
            // 
            materialButton3.AutoSize = false;
            materialButton3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton3.Depth = 0;
            materialButton3.HighEmphasis = true;
            materialButton3.Icon = null;
            materialButton3.Location = new Point(28, 442);
            materialButton3.Margin = new Padding(5, 7, 5, 7);
            materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton3.Name = "materialButton3";
            materialButton3.NoAccentTextColor = Color.Empty;
            materialButton3.Size = new Size(278, 84);
            materialButton3.TabIndex = 6;
            materialButton3.Text = "Check Synced Project Status";
            materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton3.UseAccentColor = false;
            materialButton3.UseVisualStyleBackColor = true;
            materialButton3.Click += materialButton3_Click;
            // 
            // materialButton4
            // 
            materialButton4.AutoSize = false;
            materialButton4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton4.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton4.Depth = 0;
            materialButton4.HighEmphasis = true;
            materialButton4.Icon = null;
            materialButton4.Location = new Point(338, 442);
            materialButton4.Margin = new Padding(5, 7, 5, 7);
            materialButton4.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton4.Name = "materialButton4";
            materialButton4.NoAccentTextColor = Color.Empty;
            materialButton4.Size = new Size(278, 84);
            materialButton4.TabIndex = 7;
            materialButton4.Text = "Compare Type3s";
            materialButton4.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton4.UseAccentColor = false;
            materialButton4.UseVisualStyleBackColor = true;
            materialButton4.Click += materialButton4_Click;
            // 
            // materialButton5
            // 
            materialButton5.AutoSize = false;
            materialButton5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton5.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton5.Depth = 0;
            materialButton5.HighEmphasis = true;
            materialButton5.Icon = null;
            materialButton5.Location = new Point(178, 540);
            materialButton5.Margin = new Padding(5, 7, 5, 7);
            materialButton5.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton5.Name = "materialButton5";
            materialButton5.NoAccentTextColor = Color.Empty;
            materialButton5.Size = new Size(278, 32);
            materialButton5.TabIndex = 8;
            materialButton5.Text = "MongoToOracle";
            materialButton5.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton5.UseAccentColor = false;
            materialButton5.UseVisualStyleBackColor = true;
            materialButton5.Click += materialButton5_Click;
            // 
            // OptionForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(690, 599);
            Controls.Add(materialButton5);
            Controls.Add(materialButton4);
            Controls.Add(materialButton3);
            Controls.Add(label1);
            Controls.Add(materialComboBox1);
            Controls.Add(materialButton2);
            Controls.Add(materialButton1);
            Controls.Add(btn_deleteoperations);
            Controls.Add(btn_updateoperations);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "OptionForm";
            Text = "OptionForm";
            FormClosing += OptionForm_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btn_updateoperations;
        private MaterialSkin.Controls.MaterialButton btn_deleteoperations;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox1;
        private Label label1;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private MaterialSkin.Controls.MaterialButton materialButton4;
        private MaterialSkin.Controls.MaterialButton materialButton5;
    }
}