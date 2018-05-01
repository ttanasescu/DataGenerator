using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorGUI.ConstraintsPanels.Numerics
{
    public partial class IntConstraintsPanel : UserControl
    {
        private readonly IntConstraints _constraints;

        public IntConstraintsPanel(Constraints constraints)
        {
            if (!(constraints is IntConstraints constrains))
            {
                throw new ArgumentException(nameof(constraints));
            }

            _constraints = constrains;
            InitializeComponent();
        }

        private void IntConstraintsPanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;

            minNumericUpDown.Minimum = _constraints.MinPossibleValue;
            minNumericUpDown.Maximum = _constraints.MaxPossibleValue;
            maxNumericUpDown.Minimum = _constraints.MinPossibleValue;
            maxNumericUpDown.Maximum = _constraints.MaxPossibleValue;

            minNumericUpDown.Value = _constraints.MinValue;
            maxNumericUpDown.Value = _constraints.MaxValue;

            if (!_constraints.AllowsNulls)
            {
                nullNumericUpDown.Enabled = false;
                nullPercentLabel.Enabled = false;
            }

            nullNumericUpDown.Value = _constraints.PercentOfNulls;
        }

        private void minNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _constraints.MinValue = (int) minNumericUpDown.Value;
        }

        private void maxNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _constraints.MaxValue = (int) maxNumericUpDown.Value;
        }

        private void nullNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _constraints.PercentOfNulls = (int) nullNumericUpDown.Value;
        }
    }
}
