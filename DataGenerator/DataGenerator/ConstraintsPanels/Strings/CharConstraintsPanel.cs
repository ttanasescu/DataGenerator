using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.Strings;

namespace DataGeneratorGUI.ConstraintsPanels.Strings
{
    public partial class CharConstraintsPanel : UserControl
    {
        private readonly CharConstraints _constraints;

        public CharConstraintsPanel(Constraints constraints)
        {
            if (!(constraints is CharConstraints constrains))
            {
                throw new ArgumentException(nameof(constraints));
            }

            _constraints = constrains;
            InitializeComponent();
        }

        private void CharConstraintsPanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;

            if (!_constraints.AllowsNulls)
            {
                nullNumericUpDown.Enabled = false;
                nullPercentLabel.Enabled = false;
            }

            nullNumericUpDown.Value = _constraints.PercentOfNulls;
        }
        
        private void nullNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _constraints.PercentOfNulls = (int) nullNumericUpDown.Value;
        }
    }
}
