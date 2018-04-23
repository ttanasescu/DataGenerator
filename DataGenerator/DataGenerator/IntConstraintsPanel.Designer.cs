namespace DataGeneratorGUI
{
    partial class IntConstraintsPanel
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
            this.minNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.minNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // minNumericUpDown
            // 
            this.minNumericUpDown.Location = new System.Drawing.Point(88, 59);
            this.minNumericUpDown.Name = "minNumericUpDown";
            this.minNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.minNumericUpDown.TabIndex = 0;
            this.minNumericUpDown.ValueChanged += new System.EventHandler(this.minNumericUpDown_ValueChanged);
            // 
            // maxNumericUpDown
            // 
            this.maxNumericUpDown.Location = new System.Drawing.Point(88, 103);
            this.maxNumericUpDown.Name = "maxNumericUpDown";
            this.maxNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.maxNumericUpDown.TabIndex = 1;
            this.maxNumericUpDown.ValueChanged += new System.EventHandler(this.maxNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Min Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Max Value";
            // 
            // IntConstraintsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maxNumericUpDown);
            this.Controls.Add(this.minNumericUpDown);
            this.Name = "IntConstraintsPanel";
            this.Size = new System.Drawing.Size(566, 305);
            this.Load += new System.EventHandler(this.IntConstraintsPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.minNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown minNumericUpDown;
        private System.Windows.Forms.NumericUpDown maxNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
