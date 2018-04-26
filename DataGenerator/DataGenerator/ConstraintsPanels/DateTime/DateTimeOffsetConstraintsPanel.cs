using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.DateTime;

namespace DataGeneratorGUI.ConstraintsPanels.DateTime
{
    public partial class DateTimeOffsetConstraintsPanel : UserControl
    {
        private readonly DatetimeOffsetConstraints _constraints;

        public DateTimeOffsetConstraintsPanel(Constraints constraints)
        {
            if (!(constraints is DatetimeOffsetConstraints constrains))
            {
                throw new ArgumentException(nameof(constraints));
            }

            _constraints = constrains;
            InitializeComponent();
        }

        private void DateTimeConstraintsPanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;

            minDatePicker.MinDate = _constraints.MinPossibleDatetime.DateTime;
            minDatePicker.MaxDate = _constraints.MaxPossibleDatetime.DateTime;
            maxDatePicker.MinDate = _constraints.MinPossibleDatetime.DateTime;
            maxDatePicker.MaxDate = _constraints.MaxPossibleDatetime.DateTime;

            minTimePicker.MinDate = _constraints.MinPossibleDatetime.DateTime;
            minTimePicker.MaxDate = _constraints.MaxPossibleDatetime.DateTime;
            maxTimePicker.MinDate = _constraints.MinPossibleDatetime.DateTime;
            maxTimePicker.MaxDate = _constraints.MaxPossibleDatetime.DateTime;
            
            var minOff = _constraints.MinDatetime.Offset;
            var maxOff = _constraints.MaxDatetime.Offset;

            minOffsetPicker.CustomFormat = $@"{(minOffsetPicker.Value.Hour < 12 ? "-" : "+")}hh:mm";
            maxOffsetPicker.CustomFormat = $@"{(maxOffsetPicker.Value.Hour < 12 ? "-" : "+")}hh:mm";

            minOffsetPicker.Value = new System.DateTime(2000, 1, 1, minOff.Hours+12, minOff.Minutes, 0);
            maxOffsetPicker.Value = new System.DateTime(2000, 1, 1, maxOff.Hours+12, maxOff.Minutes, 0);

            minDatePicker.Value = _constraints.MinDatetime.DateTime;
            maxDatePicker.Value = _constraints.MaxDatetime.DateTime;
                          
            minTimePicker.Value = _constraints.MinDatetime.DateTime;
            maxTimePicker.Value = _constraints.MaxDatetime.DateTime;

            if (!_constraints.AllowsNulls)
            {
                nullNumericUpDown.Enabled = false;
                nullPercentLabel.Enabled = false;
            }

            minDatePicker.ValueChanged += minDateTimePicker_ValueChanged;
            maxDatePicker.ValueChanged += maxDateTimePicker_ValueChanged;
            minTimePicker.ValueChanged += minDateTimePicker_ValueChanged;
            maxTimePicker.ValueChanged += maxDateTimePicker_ValueChanged;

            minOffsetPicker.ValueChanged += minDateTimePicker_ValueChanged;
            maxOffsetPicker.ValueChanged += maxDateTimePicker_ValueChanged;
        }

        private void nullNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _constraints.PercentOfNulls = (int) nullNumericUpDown.Value;
        }

        private void minDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            var date = minDatePicker.Value;
            var time = minTimePicker.Value;

            minOffsetPicker.CustomFormat = $@"{(minOffsetPicker.Value.Hour < 12 ? "-" : "+")}hh:mm";

            var offset = new TimeSpan(0, minOffsetPicker.Value.Hour-12, minOffsetPicker.Value.Minute, 0);
            _constraints.MinDatetime = new DateTimeOffset(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second, offset);
        }

        private void maxDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            var date = maxDatePicker.Value;
            var time = maxTimePicker.Value;

            maxOffsetPicker.CustomFormat = $@"{(maxOffsetPicker.Value.Hour < 12 ? "-" : "+")}hh:mm";

            var offset = new TimeSpan(0, maxOffsetPicker.Value.Hour - 12, maxOffsetPicker.Value.Minute, 0);
            _constraints.MaxDatetime = new DateTimeOffset(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second, offset);
        }
    }
}
