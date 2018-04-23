using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorGUI
{
    public partial class IntConstraintsPanel : UserControl
    {
        private readonly IntConstrains _intConstrains;

        public IntConstraintsPanel(Constrains constrains)
        {
            if (!(constrains is IntConstrains intConstrains))
            {
                throw new ArgumentException(nameof(constrains));
            }

            _intConstrains = intConstrains;
            InitializeComponent();
        }

        private void IntConstraintsPanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;

            minNumericUpDown.Minimum = int.MinValue;
            minNumericUpDown.Maximum = int.MaxValue;
            maxNumericUpDown.Minimum = int.MinValue;
            maxNumericUpDown.Maximum = int.MaxValue;

            minNumericUpDown.Value = _intConstrains.MinValue;
            maxNumericUpDown.Value = _intConstrains.MaxValue;
        }

        private void minNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _intConstrains.MinValue = (int) minNumericUpDown.Value;
        }

        private void maxNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _intConstrains.MaxValue = (int) maxNumericUpDown.Value;
        }
    }
}
