using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorGUI.ConstraintsPanels
{
    public partial class RealConstraintsPanel : UserControl
    {
        private readonly RealConstraints _realConstraints;

        public RealConstraintsPanel(Constraints constrains)
        {
            if (!(constrains is RealConstraints realConstraints))
            {
                throw new ArgumentException(nameof(constrains));
            }

            _realConstraints = realConstraints;
            InitializeComponent();
        }

        private void RealConstraintsPanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;

            minNumericUpDown.Minimum = (decimal) _realConstraints.MinPossibleValue;
            minNumericUpDown.Maximum = (decimal) _realConstraints.MaxPossibleValue;
            maxNumericUpDown.Minimum = (decimal) _realConstraints.MinPossibleValue;
            maxNumericUpDown.Maximum = (decimal) _realConstraints.MaxPossibleValue;

            minNumericUpDown.Value = (decimal) _realConstraints.MinValue;
            maxNumericUpDown.Value = (decimal) _realConstraints.MaxValue;
        }

        private void minNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _realConstraints.MinValue = (float) minNumericUpDown.Value;
        }

        private void maxNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _realConstraints.MaxValue = (float) maxNumericUpDown.Value;
        }
    }
}
