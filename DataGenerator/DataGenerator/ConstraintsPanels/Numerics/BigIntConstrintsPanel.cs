using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorGUI.ConstraintsPanels.Numerics
{
    public partial class BigIntConstrintsPanel : UserControl
    {
        private readonly BigIntConstraints _constraints;

        public BigIntConstrintsPanel(Constraints constraints)
        {
            if (!(constraints is BigIntConstraints bigIntConstrains))
            {
                throw new ArgumentException(nameof(constraints));
            }

            _constraints = bigIntConstrains;
            InitializeComponent();
        }

        private void BigIntConstrintsPanel_Load(object sender, EventArgs e)
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
        }

        private void minNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _constraints.MinValue = (long) minNumericUpDown.Value;
        }

        private void maxNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _constraints.MaxValue = (long) maxNumericUpDown.Value;
        }

    }
}
