using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorGUI.ConstraintsPanels.Numerics
{
    public partial class DecimalConstraintsPanel : UserControl
    {
        private readonly DecimalConstraints _constraints;

        public DecimalConstraintsPanel(Constraints constrains)
        {
            if (!(constrains is DecimalConstraints intConstrains))
            {
                throw new ArgumentException(nameof(constrains));
            }

            _constraints = intConstrains;
            InitializeComponent();
        }

        private void DecimalConstraintsPanel_Load(object sender, EventArgs e)
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
            nullNumericUpDown.ValueChanged += nullNumericUpDown_ValueChanged;
        }

        private void nullNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _constraints.PercentOfNulls = (int)nullNumericUpDown.Value;
        }

        private void minNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _constraints.MinValue = minNumericUpDown.Value;
        }

        private void maxNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _constraints.MaxValue = maxNumericUpDown.Value;
        }
    }
}
