using System;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.DateTime;

namespace DataGeneratorGUI.ConstraintsPanels.DateTime
{
    public partial class DateConstraintsPanel : UserControl
    {
        private readonly DateConstraints _constraints;

        public DateConstraintsPanel(Constraints constraints)
        {
            if (!(constraints is DateConstraints constrains))
            {
                throw new ArgumentException(nameof(constraints));
            }

            _constraints = constrains;
            InitializeComponent();
        }

        private void DateTimeConstraintsPanel_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;

            minDatePicker.MinDate = _constraints.MinPossibleDate;
            minDatePicker.MaxDate = _constraints.MaxPossibleDate;
            maxDatePicker.MinDate = _constraints.MinPossibleDate;
            maxDatePicker.MaxDate = _constraints.MaxPossibleDate;

            minDatePicker.Value = _constraints.MinDate;
            maxDatePicker.Value = _constraints.MaxDate;


            if (!_constraints.AllowsNulls)
            {
                nullNumericUpDown.Enabled = false;
                nullPercentLabel.Enabled = false;
            }

            nullNumericUpDown.Value = _constraints.PercentOfNulls;

            minDatePicker.ValueChanged += minDateTimePicker_ValueChanged;
            maxDatePicker.ValueChanged += maxDateTimePicker_ValueChanged;
        }

        private void nullNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _constraints.PercentOfNulls = (int) nullNumericUpDown.Value;
        }

        private void minDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            var date = minDatePicker.Value;
            _constraints.MinDate = new System.DateTime(date.Year, date.Month, date.Day);
        }

        private void maxDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            var date = maxDatePicker.Value;
            _constraints.MaxDate = new System.DateTime(date.Year, date.Month, date.Day);
        }
    }
}
