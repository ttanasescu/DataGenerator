using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorGUI.ConstraintsPanels
{
    public partial class FloatConstraintsPanel : UserControl
    {
        private readonly FloatConstraints _constraints;

        public FloatConstraintsPanel(Constraints constrains)
        {
            if (!(constrains is FloatConstraints floatConstraints))
            {
                throw new ArgumentException(nameof(constrains));
            }

            _constraints = floatConstraints;
            InitializeComponent();
        }

        private void FloatConstraintsPanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;

            minNumericUpDown.Minimum = (decimal) _constraints.MinPossibleValue;
            minNumericUpDown.Maximum = (decimal) _constraints.MaxPossibleValue;
            maxNumericUpDown.Minimum = (decimal) _constraints.MinPossibleValue;
            maxNumericUpDown.Maximum = (decimal) _constraints.MaxPossibleValue;

            minNumericUpDown.Value = (decimal) _constraints.MinValue;
            maxNumericUpDown.Value = (decimal) _constraints.MaxValue;

            if (!_constraints.AllowsNulls)
            {
                nullNumericUpDown.Enabled = false;
                nullPercentLabel.Enabled = false;
            }
        }

        private void minNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _constraints.MinValue = (double) minNumericUpDown.Value;
        }

        private void maxNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _constraints.MaxValue = (double) maxNumericUpDown.Value;
        }
    }
}