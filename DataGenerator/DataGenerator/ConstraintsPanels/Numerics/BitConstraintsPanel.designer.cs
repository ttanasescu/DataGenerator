namespace DataGeneratorGUI.ConstraintsPanels.Numerics
{
    partial class BitConstraintsPanel
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nullPercentLabel = new System.Windows.Forms.Label();
            this.nullNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nullPercentLabel);
            this.groupBox1.Controls.Add(this.nullNumericUpDown);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 150);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Constraints";
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
            // BitConstraintsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(500, 150);
            this.Controls.Add(this.groupBox1);
            this.Name = "BitConstraintsPanel";
            this.Size = new System.Drawing.Size(500, 150);
            this.Load += new System.EventHandler(this.BitConstraintsPanel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label nullPercentLabel;
        private System.Windows.Forms.NumericUpDown nullNumericUpDown;
    }
}
