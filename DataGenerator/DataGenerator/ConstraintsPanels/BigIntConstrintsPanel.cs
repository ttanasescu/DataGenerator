using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorGUI.ConstraintsPanels
{
    public partial class BigIntConstrintsPanel : UserControl
    {
        private readonly BigIntConstrains _bigIntConstrains;

        public BigIntConstrintsPanel(Constrains constrains)
        {
            if (!(constrains is BigIntConstrains bigIntConstrains))
            {
                throw new ArgumentException(nameof(constrains));
            }

            _bigIntConstrains = bigIntConstrains;
            InitializeComponent();
        }
        private void BigIntConstrintsPanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;

            minNumericUpDown.Minimum = long.MinValue;
            minNumericUpDown.Maximum = long.MaxValue;
            maxNumericUpDown.Minimum = long.MinValue;
            maxNumericUpDown.Maximum = long.MaxValue;

            minNumericUpDown.Value = _bigIntConstrains.MinValue;
            maxNumericUpDown.Value = _bigIntConstrains.MaxValue;
        }

        private void minNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

            _bigIntConstrains.MinValue = (long) minNumericUpDown.Value;
        }

        private void maxNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

            _bigIntConstrains.MaxValue = (long) maxNumericUpDown.Value;
        }

    }
}
