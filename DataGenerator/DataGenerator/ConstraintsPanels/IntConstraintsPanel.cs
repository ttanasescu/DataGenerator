using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorGUI.ConstraintsPanels
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

            minNumericUpDown.Minimum = _intConstrains.MinPossibleValue;
            minNumericUpDown.Maximum = _intConstrains.MaxPossibleValue;
            maxNumericUpDown.Minimum = _intConstrains.MinPossibleValue;
            maxNumericUpDown.Maximum = _intConstrains.MaxPossibleValue;

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
