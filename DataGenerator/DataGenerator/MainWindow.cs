using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataGeneratorLibrary;
using DataGeneratorLibrary.Generators;
using System.Data.SqlClient;
using System.Drawing;
using DataGeneratorGUI.ConstraintsPanels;
using DataGeneratorGUI.Forms;
using DataGeneratorLibrary.DataExport;
using DataGeneratorLibrary.DAL;

namespace DataGeneratorGUI
{
    public partial class MainWindow : Form
    {
        private TableInformation TableInformation {get; set; }

        public MainWindow()
        {
            TableInformation = new TableInformation();
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            connectToDatabaseToolStripMenuItem_Click(null, null);
        }

        private void connectToDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ConnectToDataBaseForm();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var builder = new SqlConnectionStringBuilder
                {
                    Password = form.Password,
                    UserID = form.UserName,
                    DataSource = form.ServerName,
                    IntegratedSecurity = form.WindowsAuthentication
                };

                Dal.Instance.SetConnectionSctring(builder.ConnectionString);

                try
                {
                    TableInformation.ServerName = Dal.Instance.GetServerName();
                    Text = $@"DataGenerator - {TableInformation.ServerName}";
                }
                catch (SqlException sqlException)
                {
                    MessageBox.Show(sqlException.InnerException?.Message ?? sqlException.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                selectTableToolStripMenuItem_Click(null, null);
            }
        }

        private void selectTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TableInformation.ServerName?.Trim() ?? TableInformation.ServerName))
            {
                System.Media.SystemSounds.Asterisk.Play();
                connectToDatabaseToolStripMenuItem_Click(null, null);
                return;
            }

            var form = new SelectTableForm
            {
                ServerName = TableInformation.ServerName,
                DataBase = TableInformation.Database,
                TableName = TableInformation.Tablename
            };

            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                TableInformation.Database = form.DataBase;
                TableInformation.Tablename = form.TableName;

                Text = $@"DataGenerator - {TableInformation.ServerName}\{form.DataBase}\{TableInformation.Tablename}";


                TableInformation.Columns = Dal.Instance.GetTableInformation(TableInformation.Tablename);
                LoadColums(TableInformation.Columns);

                TableInformation.Table = Dal.Instance.GetTable(TableInformation.Tablename);

                tableDataGridView.DataBindingComplete += OnDataBindingComplete;

                tableDataGridView.DataSource = TableInformation.Table;
            }
        }

        private void LoadColums(IList<Column> columns)
        {
            columnsListView.Items.Clear();

            foreach (var column in columns)
            {
                var item = new ListViewItem(column.Name);

                var typeName = column.DataType.ToString();

                switch (column.DataType)
                {
                    case TSQLDataType.@decimal:
                    case TSQLDataType.numeric:
                        if (column.NumericPrecision != null)
                            if (column.NumericScale != null)
                                typeName += $"({column.NumericPrecision}, {column.NumericScale})";
                        break;
                    case TSQLDataType.time:
                    case TSQLDataType.datetime:
                    case TSQLDataType.datetime2:
                    case TSQLDataType.datetimeoffset:
                    case TSQLDataType.@char:
                    case TSQLDataType.nchar:
                    case TSQLDataType.binary:
                    case TSQLDataType.varchar:
                    case TSQLDataType.nvarchar:
                    case TSQLDataType.varbinary:
                        if (column.CharMaxLength != null) typeName += $"({column.CharMaxLength})";
                        break;
                }

                item.SubItems.Add(typeName);
                item.SubItems.Add(column.Constraints.AllowsNulls.ToString());
                columnsListView.Items.Add(item);
            }

            if (columnsListView.Items.Count > 0) columnsListView.Items[0].Selected = true;
        }

        private void OnDataBindingComplete(object o, DataGridViewBindingCompleteEventArgs args)
        {
            for (var i = 0; i < tableDataGridView.Columns.Count; i++)
            {
                object column = tableDataGridView.Columns[i];
                if (column is DataGridViewImageColumn imageColumn)
                {
                    var textBoxColumn = new DataGridViewTextBoxColumn
                    {
                        Name = imageColumn.Name+"_textBox",
                        DisplayIndex = imageColumn.DisplayIndex,
                        HeaderText = imageColumn.HeaderText,
                        DataPropertyName = imageColumn.Name + "_textBox",
                        ReadOnly = imageColumn.ReadOnly
                    };
                    
                    tableDataGridView.Columns.Add(textBoxColumn);

                    for (var index = 0; index < TableInformation.Table.Rows.Count; index++)
                    {
                        tableDataGridView.Rows[index].Cells[textBoxColumn.Name].Value =
                            TableInformation.Table.Rows[index][imageColumn.Name];
                    }

                    tableDataGridView.Columns.Remove(imageColumn.Name);
                    textBoxColumn.Name = textBoxColumn.Name.Replace("_textBox", "");
                    textBoxColumn.DataPropertyName = textBoxColumn.Name;
                }

                ((DataGridViewColumn) column).SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void tablesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is ListView tablesListView)) return;
            if (tablesListView.SelectedItems.Count == 0) return;

            var name = tablesListView.SelectedItems[0].Text;

            var currentColumn = TableInformation.Columns.Single(column => column.Name == name);

            var panel = PanelProvider.GetPanel(currentColumn);
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(panel);
        }

        private void tableDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (sender is DataGridView gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TableInformation.ServerName?.Trim() ?? TableInformation.ServerName))
            {
                System.Media.SystemSounds.Asterisk.Play();
                connectToDatabaseToolStripMenuItem_Click(null, null);
                return;
            }

            if (string.IsNullOrEmpty(TableInformation.Tablename?.Trim() ?? TableInformation.Tablename))
            {
                System.Media.SystemSounds.Asterisk.Play();
                selectTableToolStripMenuItem_Click(null, null);
                return;
            }

            var generator = new Generator();

            generator.FillTable(TableInformation.Table, TableInformation.Columns, (int) rowCountUpDown.Value, false);
        }

        private void fillDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Dal.Instance.ClearTable(TableInformation.Tablename);
                Dal.Instance.SaveTable(TableInformation.Table);
                MessageBox.Show(@"Data successfuly loaded to DataBase!", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Could not save date to DataBase.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void insertsOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = @"Sql|*.sql",
                Title = @"Save Sql script"
            };
            var dialogResult = dialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                if (dialog.FileName != "")
                {
                    SqlScriptGeneraor.Generate(TableInformation, false, dialog.FileName);
                    MessageBox.Show(@"Succsess", $"Data saved as\r\n{dialog.FileName}");
                }
            }
        }

        private void withCreateTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = @"Sql|*.sql",
                Title = @"Save Sql script"
            };
            var dialogResult = dialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                if (dialog.FileName != "")
                {
                    SqlScriptGeneraor.Generate(TableInformation, true, dialog.FileName);
                    MessageBox.Show(@"Succsess", $"Data saved as\r\n{dialog.FileName}");
                }
            }
        }

        private void tableDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DBNull)
            {
                e.CellStyle.BackColor = Color.LightYellow;
            }

            if (e.Value is byte[] array)
            {
                var str = array.Aggregate("0x", (current, b) => current + $"{b:X}");

                e.Value = str;

                e.FormattingApplied = true;
            }
            else
            {
                e.FormattingApplied = false;
            }
        }

        private void tableDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e) { }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SQL Server Data Generator\r\nTănăsescu Tudor\r\n2018", @"About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
