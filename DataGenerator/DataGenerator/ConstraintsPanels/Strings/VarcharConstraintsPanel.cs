using System;
using System.Drawing;
using System.Windows.Forms;
using DataGeneratorLibrary.Constrains;
using DataGeneratorLibrary.Constrains.Strings;
using DataGeneratorLibrary.DataSources;
using RegExGenerator;

namespace DataGeneratorGUI.ConstraintsPanels.Strings
{
    public partial class VarcharConstraintsPanel : UserControl
    {
        private readonly VarcharConstraints _constraints;
        private ToolTip _toolTip;

        public VarcharConstraintsPanel(Constraints constraints)
        {
            if (!(constraints is VarcharConstraints constrains))
            {
                throw new ArgumentException(nameof(constraints));
            }

            _constraints = constrains;
            _toolTip = new ToolTip();
            InitializeComponent();
        }

        private void VarcharConstraintsPanel_Load(object sender, EventArgs e)
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

            nullNumericUpDown.Value = _constraints.PercentOfNulls;
            templatesComboBox.DataSource = Enum.GetValues(typeof(TemplateDataEnum));

            useTemplateCheckBox.Checked = _constraints.UseTemplateData;
            if (_constraints.UseTemplateData)
            {
                templatesComboBox.SelectedItem = _constraints.TemplateData;
            }

            templatesComboBox.SelectedIndexChanged += templatesComboBox_SelectedIndexChanged;

            regExTextBox.Text = _constraints.RegEx;
            useRegExCheckBox.Checked = _constraints.UseRegEx;

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

        private void useTemplateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (useTemplateCheckBox.Checked)
            {
                minNumericUpDown.Enabled = false;
                maxNumericUpDown.Enabled = false;
                minLenghtLabel.Enabled = false;
                maxLenghtLabel.Enabled = false;
                regExTextBox.Enabled = false;
                useRegExCheckBox.Enabled = false;

                templatesComboBox.Enabled = true;
                _constraints.UseTemplateData = true;
            }
            else
            {
                minNumericUpDown.Enabled = true;
                maxNumericUpDown.Enabled = true;
                minLenghtLabel.Enabled = true;
                maxLenghtLabel.Enabled = true;

                templatesComboBox.Enabled = false;
                _constraints.UseTemplateData = false;

                useRegExCheckBox.Enabled = true;
                
                regExTextBox.Enabled = useRegExCheckBox.Checked;
            }
        }

        private void regExCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (useRegExCheckBox.Checked)
            {
                minNumericUpDown.Enabled = false;
                maxNumericUpDown.Enabled = false;
                minLenghtLabel.Enabled = false;
                maxLenghtLabel.Enabled = false;
                templatesComboBox.Enabled = false;
                useTemplateCheckBox.Enabled = false;

                regExTextBox.Enabled = true;
                _constraints.UseRegEx = true;
            }
            else
            {
                minNumericUpDown.Enabled = true;
                maxNumericUpDown.Enabled = true;
                minLenghtLabel.Enabled = true;
                maxLenghtLabel.Enabled = true;
                templatesComboBox.Enabled = useTemplateCheckBox.Checked;
                useTemplateCheckBox.Enabled = true;

                regExTextBox.Enabled = false;
            }
        }

        private void templatesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum.TryParse(templatesComboBox.SelectedValue.ToString(), out TemplateDataEnum template);

            _constraints.TemplateData = template;
        }

        private void regExTextBox_TextChanged(object sender, EventArgs e)
        {
            _constraints.RegEx = regExTextBox.Text;

            var currentPosition = regExTextBox.SelectionStart;

            regExTextBox.SelectionStart = 0;
            regExTextBox.SelectionLength = regExTextBox.Text.Length;
            regExTextBox.SelectionFont = new Font(regExTextBox.SelectionFont, FontStyle.Regular);
            regExTextBox.SelectionColor = Color.Black;
            regExTextBox.SelectionLength = 0;

            try
            {
                _constraints.ParseRegEx();
                _toolTip.RemoveAll();
            }
            catch (RegExParsingException ex)
            {
                regExTextBox.SelectionStart = ex.Position-1;
                regExTextBox.SelectionLength = ex.Lenght;
                regExTextBox.SelectionFont = new Font(regExTextBox.SelectionFont, FontStyle.Underline);
                regExTextBox.SelectionColor = Color.Red;
                regExTextBox.SelectionLength = 0;
                //MessageBox.Show(ex.Message);

                _toolTip.SetToolTip(regExTextBox,ex.Message);
            }

            regExTextBox.SelectionStart = currentPosition;
        }
    }
}
