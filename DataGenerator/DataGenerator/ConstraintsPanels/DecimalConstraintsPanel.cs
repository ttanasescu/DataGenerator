using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorGUI.ConstraintsPanels
{
    public partial class DecimalConstraintsPanel : UserControl
    {
        private readonly DecimalConstraints _decimalConstraints;

        public DecimalConstraintsPanel(Constraints constrains)
        {
            if (!(constrains is DecimalConstraints intConstrains))
            {
                throw new ArgumentException(nameof(constrains));
            }

            _decimalConstraints = intConstrains;
            InitializeComponent();
        }

        private void DecimalConstraintsPanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;

            minNumericUpDown.Minimum = _decimalConstraints.MinPossibleValue;
            minNumericUpDown.Maximum = _decimalConstraints.MaxPossibleValue;
            maxNumericUpDown.Minimum = _decimalConstraints.MinPossibleValue;
            maxNumericUpDown.Maximum = _decimalConstraints.MaxPossibleValue;

            minNumericUpDown.Value = _decimalConstraints.MinValue;
            maxNumericUpDown.Value = _decimalConstraints.MaxValue;
        }

        private void minNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _decimalConstraints.MinValue = minNumericUpDown.Value;
        }

        private void maxNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _decimalConstraints.MaxValue = maxNumericUpDown.Value;
        }
    }
}
