using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DataGeneratorGUI.ConstraintsPanels.DateTime;
using DataGeneratorGUI.ConstraintsPanels.Numerics;
using DataGeneratorGUI.ConstraintsPanels.Strings;
using DataGeneratorLibrary;
using DataGeneratorLibrary.Generators;

namespace DataGeneratorGUI
{
    public partial class MainWindow : Form
    {
        private DataTable _table;
        private IList<Column> _columns;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
#if DEBUG
            var connectionString = ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString;
            var dal = new Dal(connectionString);
            var tablename = "Table_9";
#else
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var dal = new Dal(connectionString);
            GetDatabaseName(dal);
            var tablename = GetTableName(dal);
#endif

            _columns = dal.GetTableInformation(tablename);
            LoadColums(_columns);

            _table = dal.GetTable(tablename);
            tableDataGridView.DataSource = _table;
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

            var columnn = _columns.Single(column => column.Name == name);

            var panel = new UserControl();

            switch (columnn.DataType)
            {
                case TSQLDataType.bigint:
                    panel = new BigIntConstrintsPanel(columnn.Constraints);
                    break;
                case TSQLDataType.@int:
                    panel = new IntConstraintsPanel(columnn.Constraints);
                    break;
                case TSQLDataType.tinyint:
                    panel = new TinyIntConstraintsPanel(columnn.Constraints);
                    break;
                case TSQLDataType.smallint:
                    panel = new SmallIntConstraintsPanel(columnn.Constraints);
                    break;
                case TSQLDataType.numeric:
                case TSQLDataType.@decimal:
                    panel = new DecimalConstraintsPanel(columnn.Constraints);
                    break;
                case TSQLDataType.bit:
                    break;
                case TSQLDataType.@float:
                    panel = new FloatConstraintsPanel(columnn.Constraints);
                    break;
                case TSQLDataType.real:
                    panel = new RealConstraintsPanel(columnn.Constraints);
                    break;
                case TSQLDataType.smallmoney:
                    panel = new DecimalConstraintsPanel(columnn.Constraints);
                    break;
                case TSQLDataType.money:
                    panel = new DecimalConstraintsPanel(columnn.Constraints);
                    break;
                case TSQLDataType.time:
                    panel = new TimeConstraintsPanel(columnn.Constraints);
                    break;
                case TSQLDataType.date:
                    panel = new DateConstraintsPanel(columnn.Constraints);
                    break;
                case TSQLDataType.datetime:
                case TSQLDataType.datetime2:
                    panel = new DateTime2ConstraintsPanel(columnn.Constraints);
                    break;
                case TSQLDataType.smalldatetime:
                    panel = new SmallDatetimeConstraintsPanel(columnn.Constraints);
                    break;
                case TSQLDataType.datetimeoffset:
                    panel = new DateTimeOffsetConstraintsPanel(columnn.Constraints);
                    break;
                case TSQLDataType.nchar:
                case TSQLDataType.@char:
                case TSQLDataType.binary:
                    panel = new CharConstraintsPanel(columnn.Constraints);
                    break;
                case TSQLDataType.text:
                case TSQLDataType.ntext:
                case TSQLDataType.varchar:
                case TSQLDataType.nvarchar:
                    panel = new VarcharConstraintsPanel(columnn.Constraints);
                    break;
                case TSQLDataType.image:
                case TSQLDataType.varbinary:
                    panel = new VarbinaryConstraintsPanel(columnn.Constraints);
                    break;
                case TSQLDataType.uniqueidentifier:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(panel);
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var generator = new Generator();

            generator.FillTable(_table, _columns, 10, false);
        }
    }
}
