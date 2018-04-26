using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorGUI.ConstraintsPanels
{
    public partial class FloatConstraintsPanel : UserControl
    {
        private readonly FloatConstraints _floatConstraints;

        public FloatConstraintsPanel(Constraints constrains)
        {
            if (!(constrains is FloatConstraints floatConstraints))
            {
                throw new ArgumentException(nameof(constrains));
            }

            _floatConstraints = floatConstraints;
            InitializeComponent();
        }

        private void FloatConstraintsPanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;

            minNumericUpDown.Minimum = (decimal) _floatConstraints.MinPossibleValue;
            minNumericUpDown.Maximum = (decimal) _floatConstraints.MaxPossibleValue;
            maxNumericUpDown.Minimum = (decimal) _floatConstraints.MinPossibleValue;
            maxNumericUpDown.Maximum = (decimal) _floatConstraints.MaxPossibleValue;

            minNumericUpDown.Value = (decimal) _floatConstraints.MinValue;
            maxNumericUpDown.Value = (decimal) _floatConstraints.MaxValue;
        }

        private void minNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _floatConstraints.MinValue = (double) minNumericUpDown.Value;
        }

        private void maxNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _floatConstraints.MaxValue = (double) maxNumericUpDown.Value;
        }
    }
}