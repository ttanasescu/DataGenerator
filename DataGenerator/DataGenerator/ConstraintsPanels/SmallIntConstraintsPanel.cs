using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorGUI.ConstraintsPanels
{
    public partial class SmallIntConstraintsPanel : UserControl
    {
        private readonly SmallIntConstraints _smallIntConstraints;

        public SmallIntConstraintsPanel(Constraints constraints)
        {
            if (!(constraints is SmallIntConstraints intConstrains))
            {
                throw new ArgumentException(nameof(constraints));
            }

            _smallIntConstraints = intConstrains;
            InitializeComponent();
        }

        private void SmallIntConstraintsPanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;

            minNumericUpDown.Minimum = _smallIntConstraints.MinPossibleValue;
            minNumericUpDown.Maximum = _smallIntConstraints.MaxPossibleValue;
            maxNumericUpDown.Minimum = _smallIntConstraints.MinPossibleValue;
            maxNumericUpDown.Maximum = _smallIntConstraints.MaxPossibleValue;

            minNumericUpDown.Value = _smallIntConstraints.MinValue;
            maxNumericUpDown.Value = _smallIntConstraints.MaxValue;
        }

        private void minNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _smallIntConstraints.MinValue = (short) minNumericUpDown.Value;
        }

        private void maxNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _smallIntConstraints.MaxValue = (short) maxNumericUpDown.Value;
        }
    }
}
