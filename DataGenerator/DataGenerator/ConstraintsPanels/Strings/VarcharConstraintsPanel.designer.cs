namespace DataGeneratorGUI.ConstraintsPanels.Strings
{
    partial class VarcharConstraintsPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.maxLenghtLabel = new System.Windows.Forms.Label();
            this.minLenghtLabel = new System.Windows.Forms.Label();
            this.maxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.minNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.useTemplateCheckBox = new System.Windows.Forms.CheckBox();
            this.templatesComboBox = new System.Windows.Forms.ComboBox();
            this.nullPercentLabel = new System.Windows.Forms.Label();
            this.nullNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // maxLenghtLabel
            // 
            this.maxLenghtLabel.AutoSize = true;
            this.maxLenghtLabel.Location = new System.Drawing.Point(31, 58);
            this.maxLenghtLabel.Name = "maxLenghtLabel";
            this.maxLenghtLabel.Size = new System.Drawing.Size(63, 13);
            this.maxLenghtLabel.TabIndex = 7;
            this.maxLenghtLabel.Text = "Max Length";
            // 
            // minLenghtLabel
            // 
            this.minLenghtLabel.AutoSize = true;
            this.minLenghtLabel.Location = new System.Drawing.Point(34, 32);
            this.minLenghtLabel.Name = "minLenghtLabel";
            this.minLenghtLabel.Size = new System.Drawing.Size(60, 13);
            this.minLenghtLabel.TabIndex = 6;
            this.minLenghtLabel.Text = "Min Length";
            // 
            // maxNumericUpDown
            // 
            this.maxNumericUpDown.Location = new System.Drawing.Point(100, 56);
            this.maxNumericUpDown.Name = "maxNumericUpDown";
            this.maxNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.maxNumericUpDown.TabIndex = 5;
            // 
            // minNumericUpDown
            // 
            this.minNumericUpDown.Location = new System.Drawing.Point(100, 30);
            this.minNumericUpDown.Name = "minNumericUpDown";
            this.minNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.minNumericUpDown.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.useTemplateCheckBox);
            this.groupBox1.Controls.Add(this.templatesComboBox);
            this.groupBox1.Controls.Add(this.nullPercentLabel);
            this.groupBox1.Controls.Add(this.nullNumericUpDown);
            this.groupBox1.Controls.Add(this.minNumericUpDown);
            this.groupBox1.Controls.Add(this.maxLenghtLabel);
            this.groupBox1.Controls.Add(this.maxNumericUpDown);
            this.groupBox1.Controls.Add(this.minLenghtLabel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 150);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Constraints";
            // 
            // useTemplateCheckBox
            // 
            this.useTemplateCheckBox.AutoSize = true;
            this.useTemplateCheckBox.Location = new System.Drawing.Point(257, 31);
            this.useTemplateCheckBox.Name = "useTemplateCheckBox";
            this.useTemplateCheckBox.Size = new System.Drawing.Size(112, 17);
            this.useTemplateCheckBox.TabIndex = 10;
            this.useTemplateCheckBox.Text = "Use template data";
            this.useTemplateCheckBox.UseVisualStyleBackColor = true;
            this.useTemplateCheckBox.CheckedChanged += new System.EventHandler(this.useTemplateCheckBox_CheckedChanged);
            // 
            // templatesComboBox
            // 
            this.templatesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templatesComboBox.Enabled = false;
            this.templatesComboBox.FormattingEnabled = true;
            this.templatesComboBox.Location = new System.Drawing.Point(257, 55);
            this.templatesComboBox.Name = "templatesComboBox";
            this.templatesComboBox.Size = new System.Drawing.Size(138, 21);
            this.templatesComboBox.TabIndex = 0;
            // 
            // nullPercentLabel
            // 
            this.nullPercentLabel.AutoSize = true;
            this.nullPercentLabel.Location = new System.Drawing.Point(48, 102);
            this.nullPercentLabel.Name = "nullPercentLabel";
            this.nullPercentLabel.Size = new System.Drawing.Size(46, 13);
            this.nullPercentLabel.TabIndex = 9;
            this.nullPercentLabel.Text = "% NULL";
            // 
            // nullNumericUpDown
            // 
            this.nullNumericUpDown.Location = new System.Drawing.Point(100, 100);
            this.nullNumericUpDown.Name = "nullNumericUpDown";
            this.nullNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.nullNumericUpDown.TabIndex = 8;
            this.nullNumericUpDown.ValueChanged += new System.EventHandler(this.nullNumericUpDown_ValueChanged);
            // 
            // VarcharConstraintsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(500, 150);
            this.Controls.Add(this.groupBox1);
            this.Name = "VarcharConstraintsPanel";
            this.Size = new System.Drawing.Size(500, 150);
            this.Load += new System.EventHandler(this.VarcharConstraintsPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maxNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label maxLenghtLabel;
        private System.Windows.Forms.Label minLenghtLabel;
        private System.Windows.Forms.NumericUpDown maxNumericUpDown;
        private System.Windows.Forms.NumericUpDown minNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label nullPercentLabel;
        private System.Windows.Forms.NumericUpDown nullNumericUpDown;
        private System.Windows.Forms.ComboBox templatesComboBox;
        private System.Windows.Forms.CheckBox useTemplateCheckBox;
    }
}
