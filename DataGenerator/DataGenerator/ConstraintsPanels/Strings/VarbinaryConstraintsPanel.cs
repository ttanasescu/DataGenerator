using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.Strings;

namespace DataGeneratorGUI.ConstraintsPanels.Strings
{
    public partial class VarbinaryConstraintsPanel : UserControl
    {
        private readonly VarbinaryConstraints _constraints;

        public VarbinaryConstraintsPanel(Constraints constraints)
        {
            if (!(constraints is VarbinaryConstraints constrains))
            {
                throw new ArgumentException(nameof(constraints));
            }

            _constraints = constrains;
            InitializeComponent();
        }

        private void VarbinaryConstraintsPanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;

            minNumericUpDown.Minimum = _constraints.MinPossibleLength;
            minNumericUpDown.Maximum = _constraints.MaxPossibleLength;
            maxNumericUpDown.Minimum = _constraints.MinPossibleLength;
            maxNumericUpDown.Maximum = _constraints.MaxPossibleLength;

            minNumericUpDown.Value = _constraints.MinLength;
            maxNumericUpDown.Value = _constraints.MaxLength;


            minNumericUpDown.ValueChanged += minNumericUpDown_ValueChanged;
            maxNumericUpDown.ValueChanged += maxNumericUpDown_ValueChanged;

            if (!_constraints.AllowsNulls)
            {
                nullNumericUpDown.Enabled = false;
                nullPercentLabel.Enabled = false;
            }
        }

        private void minNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _constraints.MinLength = (int) minNumericUpDown.Value;
        }

        private void maxNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _constraints.MaxLength = (int) maxNumericUpDown.Value;
        }

        private void nullNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _constraints.PercentOfNulls = (int) nullNumericUpDown.Value;
        }
    }
}
