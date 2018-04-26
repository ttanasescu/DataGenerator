namespace DataGeneratorGUI.ConstraintsPanels.DateTime
{
    partial class DateTimeOffsetConstraintsPanel
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maxTimePicker = new System.Windows.Forms.DateTimePicker();
            this.minTimePicker = new System.Windows.Forms.DateTimePicker();
            this.maxDatePicker = new System.Windows.Forms.DateTimePicker();
            this.minDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nullPercentLabel = new System.Windows.Forms.Label();
            this.nullNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxOffsetPicker = new System.Windows.Forms.DateTimePicker();
            this.minOffsetPicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Max";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Min";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maxOffsetPicker);
            this.groupBox1.Controls.Add(this.minOffsetPicker);
            this.groupBox1.Controls.Add(this.maxTimePicker);
            this.groupBox1.Controls.Add(this.minTimePicker);
            this.groupBox1.Controls.Add(this.maxDatePicker);
            this.groupBox1.Controls.Add(this.minDatePicker);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nullPercentLabel);
            this.groupBox1.Controls.Add(this.nullNumericUpDown);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 150);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // maxTimePicker
            // 
            this.maxTimePicker.CustomFormat = "";
            this.maxTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.maxTimePicker.Location = new System.Drawing.Point(196, 56);
            this.maxTimePicker.Name = "maxTimePicker";
            this.maxTimePicker.ShowUpDown = true;
            this.maxTimePicker.Size = new System.Drawing.Size(80, 20);
            this.maxTimePicker.TabIndex = 15;
            // 
            // minTimePicker
            // 
            this.minTimePicker.CustomFormat = "";
            this.minTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.minTimePicker.Location = new System.Drawing.Point(196, 30);
            this.minTimePicker.Name = "minTimePicker";
            this.minTimePicker.ShowUpDown = true;
            this.minTimePicker.Size = new System.Drawing.Size(80, 20);
            this.minTimePicker.TabIndex = 14;
            // 
            // maxDatePicker
            // 
            this.maxDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.maxDatePicker.Location = new System.Drawing.Point(100, 56);
            this.maxDatePicker.Name = "maxDatePicker";
            this.maxDatePicker.Size = new System.Drawing.Size(90, 20);
            this.maxDatePicker.TabIndex = 13;
            // 
            // minDatePicker
            // 
            this.minDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.minDatePicker.Location = new System.Drawing.Point(100, 30);
            this.minDatePicker.Name = "minDatePicker";
            this.minDatePicker.Size = new System.Drawing.Size(90, 20);
            this.minDatePicker.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Date";
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
            // maxOffsetPicker
            // 
            this.maxOffsetPicker.CustomFormat = "+hh:mm";
            this.maxOffsetPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.maxOffsetPicker.Location = new System.Drawing.Point(282, 56);
            this.maxOffsetPicker.MaxDate = new System.DateTime(2000, 1, 3, 0, 0, 0, 0);
            this.maxOffsetPicker.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.maxOffsetPicker.Name = "maxOffsetPicker";
            this.maxOffsetPicker.ShowUpDown = true;
            this.maxOffsetPicker.Size = new System.Drawing.Size(80, 20);
            this.maxOffsetPicker.TabIndex = 17;
            this.maxOffsetPicker.Value = new System.DateTime(2000, 1, 2, 0, 0, 0, 0);
            // 
            // minOffsetPicker
            // 
            this.minOffsetPicker.CustomFormat = "-hh:mm";
            this.minOffsetPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.minOffsetPicker.Location = new System.Drawing.Point(282, 30);
            this.minOffsetPicker.MaxDate = new System.DateTime(2000, 1, 3, 0, 0, 0, 0);
            this.minOffsetPicker.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.minOffsetPicker.Name = "minOffsetPicker";
            this.minOffsetPicker.ShowUpDown = true;
            this.minOffsetPicker.Size = new System.Drawing.Size(80, 20);
            this.minOffsetPicker.TabIndex = 16;
            this.minOffsetPicker.Value = new System.DateTime(2000, 1, 2, 0, 0, 0, 0);
            // 
            // DateTimeOffsetConstraintsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(500, 150);
            this.Controls.Add(this.groupBox1);
            this.Name = "DateTimeOffsetConstraintsPanel";
            this.Size = new System.Drawing.Size(500, 150);
            this.Load += new System.EventHandler(this.DateTimeConstraintsPanel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label nullPercentLabel;
        private System.Windows.Forms.NumericUpDown nullNumericUpDown;
        private System.Windows.Forms.DateTimePicker minDatePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker maxDatePicker;
        private System.Windows.Forms.DateTimePicker maxTimePicker;
        private System.Windows.Forms.DateTimePicker minTimePicker;
        private System.Windows.Forms.DateTimePicker maxOffsetPicker;
        private System.Windows.Forms.DateTimePicker minOffsetPicker;
    }
}
