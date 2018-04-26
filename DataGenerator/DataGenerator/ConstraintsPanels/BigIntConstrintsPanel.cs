using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorGUI.ConstraintsPanels
{
    public partial class BigIntConstrintsPanel : UserControl
    {
        private readonly BigIntConstraints _bigIntConstraints;

        public BigIntConstrintsPanel(Constraints constraints)
        {
            if (!(constraints is BigIntConstraints bigIntConstrains))
            {
                throw new ArgumentException(nameof(constraints));
            }

            _bigIntConstraints = bigIntConstrains;
            InitializeComponent();
        }

        private void BigIntConstrintsPanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;

            minNumericUpDown.Minimum = _bigIntConstraints.MinPossibleValue;
            minNumericUpDown.Maximum = _bigIntConstraints.MaxPossibleValue;
            maxNumericUpDown.Minimum = _bigIntConstraints.MinPossibleValue;
            maxNumericUpDown.Maximum = _bigIntConstraints.MaxPossibleValue;

            minNumericUpDown.Value = _bigIntConstraints.MinValue;
            maxNumericUpDown.Value = _bigIntConstraints.MaxValue;
        }

        private void minNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _bigIntConstraints.MinValue = (long) minNumericUpDown.Value;
        }

        private void maxNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _bigIntConstraints.MaxValue = (long) maxNumericUpDown.Value;
        }

    }
}
