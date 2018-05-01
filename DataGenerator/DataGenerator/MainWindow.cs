using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DataGeneratorGUI.ConstraintsPanels.DateTime;
using DataGeneratorGUI.ConstraintsPanels.Numerics;
using DataGeneratorGUI.ConstraintsPanels.Strings;
using DataGeneratorLibrary;
using DataGeneratorLibrary.Generators;
using System.Data.SqlClient;
using DataGeneratorGUI.ConstraintsPanels.Other;
using DataGeneratorGUI.Forms;

namespace DataGeneratorGUI
{
    public partial class MainWindow : Form
    {
        private DataTable _table;
        private IList<Column> _columns;
        private Dal _dal;
        private string _tablename;
        private string _serverName;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            connectToDatabaseToolStripMenuItem_Click(null, null);
        }

        private void LoadColums(IList<Column> columns)
        {
            foreach (var column in columns)
            {
                var item = new ListViewItem(column.Name);

                var typeName = column.DataType.ToString();

                switch (column.DataType)
                {
                    case TSQLDataType.@decimal:
                    case TSQLDataType.numeric:
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
                        typeName += $"({column.CharMaxLength})";
                        break;
                }

                item.SubItems.Add(typeName);
                item.SubItems.Add(column.Constraints.AllowsNulls.ToString());
                listView1.Items.Add(item);
            }
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(sender is ListView listView)) return;
            if (listView.SelectedItems.Count == 0) return;

            string name = listView.SelectedItems[0].Text;

            var currentColumn = _columns.Single(column => column.Name == name);

            UserControl panel;

            switch (currentColumn.DataType)
            {
                case TSQLDataType.bigint:
                    panel = new BigIntConstrintsPanel(currentColumn.Constraints);
                    break;
                case TSQLDataType.@int:
                    panel = new IntConstraintsPanel(currentColumn.Constraints);
                    break;
                case TSQLDataType.tinyint:
                    panel = new TinyIntConstraintsPanel(currentColumn.Constraints);
                    break;
                case TSQLDataType.smallint:
                    panel = new SmallIntConstraintsPanel(currentColumn.Constraints);
                    break;
                case TSQLDataType.numeric:
                case TSQLDataType.@decimal:
                    panel = new DecimalConstraintsPanel(currentColumn.Constraints);
                    break;
                case TSQLDataType.bit:
                    panel = new BitConstraintsPanel(currentColumn.Constraints);
                    break;
                case TSQLDataType.@float:
                    panel = new FloatConstraintsPanel(currentColumn.Constraints);
                    break;
                case TSQLDataType.real:
                    panel = new RealConstraintsPanel(currentColumn.Constraints);
                    break;
                case TSQLDataType.smallmoney:
                    panel = new DecimalConstraintsPanel(currentColumn.Constraints);
                    break;
                case TSQLDataType.money:
                    panel = new DecimalConstraintsPanel(currentColumn.Constraints);
                    break;
                case TSQLDataType.time:
                    panel = new TimeConstraintsPanel(currentColumn.Constraints);
                    break;
                case TSQLDataType.date:
                    panel = new DateConstraintsPanel(currentColumn.Constraints);
                    break;
                case TSQLDataType.datetime:
                case TSQLDataType.datetime2:
                    panel = new DateTime2ConstraintsPanel(currentColumn.Constraints);
                    break;
                case TSQLDataType.smalldatetime:
                    panel = new SmallDatetimeConstraintsPanel(currentColumn.Constraints);
                    break;
                case TSQLDataType.datetimeoffset:
                    panel = new DateTimeOffsetConstraintsPanel(currentColumn.Constraints);
                    break;
                case TSQLDataType.nchar:
                case TSQLDataType.@char:
                case TSQLDataType.binary:
                    panel = new CharConstraintsPanel(currentColumn.Constraints);
                    break;
                case TSQLDataType.text:
                case TSQLDataType.ntext:
                case TSQLDataType.varchar:
                case TSQLDataType.nvarchar:
                    panel = new VarcharConstraintsPanel(currentColumn.Constraints);
                    break;
                case TSQLDataType.image:
                case TSQLDataType.varbinary:
                    panel = new VarbinaryConstraintsPanel(currentColumn.Constraints);
                    break;
                case TSQLDataType.uniqueidentifier:
                    panel = new UniqueIdentifierConstraintsPanel(currentColumn.Constraints);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(panel);
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_serverName?.Trim() ?? _serverName))
            {
                System.Media.SystemSounds.Asterisk.Play();
                connectToDatabaseToolStripMenuItem_Click(null, null);
                return;
            }

            if (string.IsNullOrEmpty(_tablename?.Trim() ?? _tablename))
            {
                System.Media.SystemSounds.Asterisk.Play();
                selectTableToolStripMenuItem_Click(null, null);
                return;
            }

            var generator = new Generator();

            generator.FillTable(_table, _columns, 10, false);
        }

        private void connectToDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ConnectToDataBaseForm();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                Debug.WriteLine(form.ServerName);
                Debug.WriteLine(form.WindowsAuthentication);
                Debug.WriteLine(form.UserName);
                Debug.WriteLine(form.Password);

                var builder = new SqlConnectionStringBuilder
                {
                    Password = form.Password,
                    UserID = form.UserName,
                    DataSource = form.ServerName,
                    IntegratedSecurity = form.WindowsAuthentication
                };
                
                _dal = new Dal(builder.ConnectionString);

                _serverName = _dal.GetServerName();
                Text = $@"DataGenerator - {_serverName}";

                selectTableToolStripMenuItem_Click(null, null);
            }
        }

        private void selectTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_serverName?.Trim() ?? _serverName))
            {
                System.Media.SystemSounds.Asterisk.Play();
                connectToDatabaseToolStripMenuItem_Click(null, null);
                return;
            }

            var form = new SelectTableForm(_dal) {ServerName = _serverName};

            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                _dal.Database = form.DataBase;
                _tablename = form.TableName;

                Text = $@"DataGenerator - {_serverName}\{form.DataBase}\{_tablename}";
                
                _columns = _dal.GetTableInformation(_tablename);
                LoadColums(_columns);

                _table = _dal.GetTable(_tablename);
                tableDataGridView.DataSource = _table;
            }
        }
    }
}
