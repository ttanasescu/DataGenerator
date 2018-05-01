using System;
using System.Windows.Forms;

namespace DataGeneratorGUI.Forms
{
    public partial class ConnectToDataBaseForm : Form
    {
        public string ServerName { get; set; }
        public bool WindowsAuthentication => (string) authenticationComboBox.SelectedItem == "Windows Authentication";

        public string UserName { get; set; }
        public string Password { get; set; }

        public ConnectToDataBaseForm()
        {
            InitializeComponent();
        }

        private void ConnectToDataBaseForm_Load(object sender, EventArgs e)
        {
            authenticationComboBox.SelectedIndex = 0;
            connectButton.DialogResult = DialogResult.OK;

            serverNameTextBox.KeyDown += OnTextBoxKeyDown;
            authenticationComboBox.KeyDown += OnTextBoxKeyDown;
            userNameTextBox.KeyDown += OnTextBoxKeyDown;
            passwordTextBox.KeyDown += OnTextBoxKeyDown;
        }

        private void OnTextBoxKeyDown(object o, KeyEventArgs args)
        {
            if (args.KeyCode == Keys.Enter)
            {
                connectButton_Click(null, null);
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (serverNameTextBox.Text.Trim() == "")
            {
                connectButton.DialogResult = DialogResult.None;
                DialogResult = DialogResult.None;
                serverNameTextBox.Focus();
                return;
            }

            if (!WindowsAuthentication)
            {
                if (userNameTextBox.Text.Trim() == "")
                {
                    connectButton.DialogResult = DialogResult.None;
                    DialogResult = DialogResult.None;
                    userNameTextBox.Focus();
                }
            }
            else
            {
                connectButton.DialogResult = DialogResult.OK;
                DialogResult = DialogResult.OK;
            }
        }

        private void authenticationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (authenticationComboBox.SelectedIndex == 0)
            {
                userNameTextBox.Enabled = false;
                passwordTextBox.Enabled = false;
                usernameLabel.Enabled = false;
                passwordLabel.Enabled = false;
            }
            else
            {
                userNameTextBox.Enabled = true;
                passwordTextBox.Enabled = true;
                usernameLabel.Enabled = true;
                passwordLabel.Enabled = true;
            }
        }

        private void ConnectToDataBaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serverNameTextBox.Text.Trim() == "" && connectButton.DialogResult == DialogResult.None)
            {
                e.Cancel = true;
                connectButton.DialogResult = DialogResult.OK;
                DialogResult = DialogResult.OK;
                System.Media.SystemSounds.Hand.Play();
                return;
            }

            if (!WindowsAuthentication)
            {
                if (userNameTextBox.Text.Trim() == "")
                {
                    e.Cancel = true;
                    connectButton.DialogResult = DialogResult.OK;
                    DialogResult = DialogResult.OK;
                    System.Media.SystemSounds.Hand.Play();
                    return;
                }
            }

            ServerName = serverNameTextBox.Text;
            UserName = userNameTextBox.Text;
            Password = passwordTextBox.Text;
        }
    }
}