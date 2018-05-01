using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.Other;

namespace DataGeneratorGUI.ConstraintsPanels.Other
{
    public partial class UniqueIdentifierConstraintsPanel : UserControl
    {
        private readonly UniqueIdentifierConstraints _constraints;

        public UniqueIdentifierConstraintsPanel(Constraints constraints)
        {
            if (!(constraints is UniqueIdentifierConstraints constrains))
            {
                throw new ArgumentException(nameof(constraints));
            }

            _constraints = constrains;
            InitializeComponent();
        }

        private void UniqueIdentifierConstraintsPanel_Load(object sender, EventArgs e)
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
