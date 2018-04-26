using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DataGeneratorGUI.ConstraintsPanels;
using DataGeneratorLibrary;
using DataGeneratorLibrary.Constrains.Numerics;
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
            var tablename = "Table_5";
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

            foreach (var column in _columns)
            {
                switch (column.DataType)
                {
                    case TSQLDataType.@int:
                        column.Constraints = new IntConstraints(); // { MinValue = 5, MaxValue = 300 };
                        break;
                    case TSQLDataType.bigint:
                        column.Constraints = new BigIntConstraints { MinValue = 5, MaxValue = 300 }; //();
                        break;
                    case TSQLDataType.tinyint:
                        column.Constraints = new TinyIntConstraints { MinValue = 5, MaxValue = 100 }; //();
                        break;
                    case TSQLDataType.money:
                        column.Constraints = new MoneyConstraints();
                        break;
                    case TSQLDataType.smallmoney:
                        column.Constraints = new SmallMoneyConstraints();
                        break;
                    case TSQLDataType.numeric:
                    case TSQLDataType.@decimal:
                        column.Constraints = column.NumericPrecision != null && column.NumericScale != null
                            ? new DecimalConstraints(column.NumericPrecision.Value, column.NumericScale.Value)
                            : new DecimalConstraints();
                        //column.constrains = new DecimalConstrains(column.NumericPrecision, column.NumericScale);
                        break;
                    case TSQLDataType.bit:
                        break;
                    case TSQLDataType.smallint:
                        column.Constraints = new SmallIntConstraints();
                        break;
                    case TSQLDataType.@float:
                        column.Constraints = new FloatConstraints();
                        break;
                    case TSQLDataType.real:
                        column.Constraints = new RealConstraints();
                        break;
                    case TSQLDataType.date:
                        break;
                    case TSQLDataType.datetime:
                        break;
                    case TSQLDataType.datetime2:
                        break;
                    case TSQLDataType.datetimeoffset:
                        break;
                    case TSQLDataType.smalldatetime:
                        break;
                    case TSQLDataType.time:
                        break;
                    case TSQLDataType.@char:
                        break;
                    case TSQLDataType.varchar:
                        break;
                    case TSQLDataType.nchar:
                        break;
                    case TSQLDataType.nvarchar:
                        break;
                    case TSQLDataType.binary:
                        break;
                    case TSQLDataType.varbinary:
                        break;
                    case TSQLDataType.ntext:
                        break;
                    case TSQLDataType.text:
                        break;
                    case TSQLDataType.image:
                        break;
                    case TSQLDataType.uniqueidentifier:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void LoadColums(IList<Column> columns)
        {
            foreach (var column in columns)
            {
                var item = new ListViewItem(column.Name);
                item.SubItems.Add(column.DataType.ToString());
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
                case TSQLDataType.date:
                    break;
                case TSQLDataType.datetime:
                    break;
                case TSQLDataType.datetime2:
                    break;
                case TSQLDataType.datetimeoffset:
                    break;
                case TSQLDataType.smalldatetime:
                    break;
                case TSQLDataType.time:
                    break;
                case TSQLDataType.@char:
                    break;
                case TSQLDataType.varchar:
                    break;
                case TSQLDataType.nchar:
                    break;
                case TSQLDataType.nvarchar:
                    break;
                case TSQLDataType.binary:
                    break;
                case TSQLDataType.varbinary:
                    break;
                case TSQLDataType.ntext:
                    break;
                case TSQLDataType.text:
                    break;
                case TSQLDataType.image:
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
