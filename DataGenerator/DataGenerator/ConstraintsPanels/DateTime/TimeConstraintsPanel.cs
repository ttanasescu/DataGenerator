using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.DateTime;

namespace DataGeneratorGUI.ConstraintsPanels.DateTime
{
    public partial class TimeConstraintsPanel : UserControl
    {
        private readonly TimeConstraints _constraints;

        public TimeConstraintsPanel(Constraints constraints)
        {
            if (!(constraints is TimeConstraints constrains))
            {
                throw new ArgumentException(nameof(constraints));
            }

            _constraints = constrains;
            InitializeComponent();
        }

        private void DateTimeConstraintsPanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;

            var minPo = _constraints.MinPossibleTime;
            var maxPo = _constraints.MaxPossibleTime;
            
            minTimePicker.MinDate = new System.DateTime(2000, 1, 1, minPo.Hours, minPo.Minutes, minPo.Seconds, minPo.Milliseconds);
            minTimePicker.MaxDate = new System.DateTime(2000, 1, 1, maxPo.Hours, maxPo.Minutes, maxPo.Seconds, maxPo.Milliseconds);
            maxTimePicker.MinDate = new System.DateTime(2000, 1, 1, minPo.Hours, minPo.Minutes, minPo.Seconds, minPo.Milliseconds);
            maxTimePicker.MaxDate = new System.DateTime(2000, 1, 1, maxPo.Hours, maxPo.Minutes, maxPo.Seconds, maxPo.Milliseconds);


            var min = _constraints.MinTime;
            var max = _constraints.MaxTime;

            minTimePicker.Value = new System.DateTime(2000, 1, 1, min.Hours, min.Minutes, min.Seconds, min.Milliseconds);
            maxTimePicker.Value = new System.DateTime(2000, 1, 1, max.Hours, max.Minutes, max.Seconds, max.Milliseconds);

            if (!_constraints.AllowsNulls)
            {
                nullNumericUpDown.Enabled = false;
                nullPercentLabel.Enabled = false;
            }

            nullNumericUpDown.Value = _constraints.PercentOfNulls;

            minTimePicker.ValueChanged += minDateTimePicker_ValueChanged;
            maxTimePicker.ValueChanged += maxDateTimePicker_ValueChanged;
        }

        private void nullNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _constraints.PercentOfNulls = (int) nullNumericUpDown.Value;
        }

        private void minDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            var time = minTimePicker.Value;
            _constraints.MinTime = new TimeSpan(0, time.Hour, time.Minute, time.Second);
        }

        private void maxDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            var time = maxTimePicker.Value;
            _constraints.MaxTime = new TimeSpan(0, time.Hour, time.Minute, time.Second);
        }
    }
}
