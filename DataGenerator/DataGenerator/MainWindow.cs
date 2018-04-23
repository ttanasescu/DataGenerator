using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using DataGeneratorLibrary;
using DataGeneratorLibrary.Constrains.Numerics;
using DataGeneratorLibrary.Generators;

namespace DataGeneratorGUI
{
    public partial class MainWindow : Form
    {
        private DataTable table;
            private IList<Column> columns;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

#if DEBUG
            var connectionString = ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString;
            var dal = new Dal(connectionString);
            var tablename = "Table_3";
#else
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var dal = new Dal(connectionString);
            GetDatabaseName(dal);
            var tablename = GetTableName(dal);
#endif
            
            columns = dal.GetTableInformation(tablename);
            LoadColums(columns);

            table = dal.GetTable(tablename);
            tableDataGridView.DataSource = table;


            var intConstrains = new IntConstrains();
            var panel = new IntConstraintsPanel(intConstrains);


            foreach (var column in columns)
            {
                switch (column.DataType)
                {
                    case TSQLDataType.@int:
                        column.constrains = intConstrains; // { MinValue = 5, MaxValue = 300 };
                        break;
                    case TSQLDataType.bigint:
                        column.constrains = new BigIntConstrains { MinValue = 5, MaxValue = 300 }; //();
                        break;
                    case TSQLDataType.money:
                        column.constrains = new MoneyConstrains();
                        break;
                    case TSQLDataType.smallmoney:
                        column.constrains = new SmallMoneyConstrains();
                        break;
                    case TSQLDataType.numeric:
                    case TSQLDataType.@decimal:
                        column.constrains = column.NumericPrecision != null && column.NumericScale != null
                            ? new DecimalConstrains(column.NumericPrecision.Value, column.NumericScale.Value)
                            : new DecimalConstrains();
                        //column.constrains = new DecimalConstrains(column.NumericPrecision, column.NumericScale);
                        break;
                }
            }


            splitContainer2.Panel1.Controls.Add(panel);

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

        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var generator = new Generator();


            generator.FillTable(table, columns, 10, false);
        }
    }
}
