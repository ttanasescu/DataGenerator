using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorGUI.ConstraintsPanels
{
    public partial class IntConstraintsPanel : UserControl
    {
        private readonly IntConstraints _intConstraints;

        public IntConstraintsPanel(Constraints constraints)
        {
            if (!(constraints is IntConstraints intConstrains))
            {
                throw new ArgumentException(nameof(constraints));
            }

            _intConstraints = intConstrains;
            InitializeComponent();
        }

        private void IntConstraintsPanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;

            minNumericUpDown.Minimum = _intConstraints.MinPossibleValue;
            minNumericUpDown.Maximum = _intConstraints.MaxPossibleValue;
            maxNumericUpDown.Minimum = _intConstraints.MinPossibleValue;
            maxNumericUpDown.Maximum = _intConstraints.MaxPossibleValue;

            minNumericUpDown.Value = _intConstraints.MinValue;
            maxNumericUpDown.Value = _intConstraints.MaxValue;
        }

        private void minNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _intConstraints.MinValue = (int) minNumericUpDown.Value;
        }

        private void maxNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _intConstraints.MaxValue = (int) maxNumericUpDown.Value;
        }
    }
}
