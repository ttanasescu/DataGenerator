using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.Numerics;

namespace DataGeneratorGUI.ConstraintsPanels
{
    public partial class TinyIntConstraintsPanel : UserControl
    {
        private readonly TinyIntConstraints _tinyIntConstraints;

        public TinyIntConstraintsPanel(Constraints constraints)
        {
            if (!(constraints is TinyIntConstraints tinyIntConstrains))
            {
                throw new ArgumentException(nameof(constraints));
            }

            _tinyIntConstraints = tinyIntConstrains;
            InitializeComponent();
        }

        private void TinyIntConstraintsPanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;

            minNumericUpDown.Minimum = _tinyIntConstraints.MinPossibleValue;
            minNumericUpDown.Maximum = _tinyIntConstraints.MaxPossibleValue;
            maxNumericUpDown.Minimum = _tinyIntConstraints.MinPossibleValue;
            maxNumericUpDown.Maximum = _tinyIntConstraints.MaxPossibleValue;

            minNumericUpDown.Value = _tinyIntConstraints.MinValue;
            maxNumericUpDown.Value = _tinyIntConstraints.MaxValue;
        }

        private void minNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _tinyIntConstraints.MinValue = (byte) minNumericUpDown.Value;
        }

        private void maxNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _tinyIntConstraints.MaxValue = (byte) maxNumericUpDown.Value;
        }
    }
}
