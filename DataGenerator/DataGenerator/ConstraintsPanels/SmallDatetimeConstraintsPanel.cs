using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.DateTime;

namespace DataGeneratorGUI.ConstraintsPanels.DateTime
{
    public partial class SmallDatetimeConstraintsPanel : UserControl
    {
        private readonly SmallDatetimeConstraints _constraints;

        public SmallDatetimeConstraintsPanel(Constraints constraints)
        {
            if (!(constraints is SmallDatetimeConstraints constrains))
            {
                throw new ArgumentException(nameof(constraints));
            }

            _constraints = constrains;
            InitializeComponent();
        }

        private void SmallDatetimeConstraintsPanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;

            minDatePicker.MinDate = _constraints.MinPossibleDatetime;
            minDatePicker.MaxDate = _constraints.MaxPossibleDatetime;
            maxDatePicker.MinDate = _constraints.MinPossibleDatetime;
            maxDatePicker.MaxDate = _constraints.MaxPossibleDatetime;

            minTimePicker.MinDate = _constraints.MinPossibleDatetime;
            minTimePicker.MaxDate = _constraints.MaxPossibleDatetime;
            maxTimePicker.MinDate = _constraints.MinPossibleDatetime;
            maxTimePicker.MaxDate = _constraints.MaxPossibleDatetime;

            minDatePicker.Value = _constraints.MinDatetime;
            maxDatePicker.Value = _constraints.MaxDatetime;
                          
            minTimePicker.Value = _constraints.MinDatetime;
            maxTimePicker.Value = _constraints.MaxDatetime;

            if (!_constraints.AllowsNulls)
            {
                nullNumericUpDown.Enabled = false;
                nullPercentLabel.Enabled = false;
            }

            minDatePicker.ValueChanged += minDateTimePicker_ValueChanged;
            maxDatePicker.ValueChanged += maxDateTimePicker_ValueChanged;
            minTimePicker.ValueChanged += minDateTimePicker_ValueChanged;
            maxTimePicker.ValueChanged += maxDateTimePicker_ValueChanged;
        }

        private void nullNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _constraints.PercentOfNulls = (int) nullNumericUpDown.Value;
        }

        private void minDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            var date = minDatePicker.Value;
            var time = minTimePicker.Value;
            _constraints.MinDatetime = new System.DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
        }

        private void maxDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            var date = maxDatePicker.Value;
            var time = maxTimePicker.Value;
            _constraints.MaxDatetime = new System.DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
        }
    }
}
