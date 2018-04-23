using System;
using System.Configuration;
using System.Windows.Forms;
using DataGeneratorLibrary;

namespace DataGeneratorGUI
{
    public partial class MainWindow : Form
    {
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
            
            var columns = dal.GetTableInformation(tablename);
            var table = dal.GetTable(tablename);


            tableDataGridView.DataSource = table;


            LoadColums(columns);
        }

        private void LoadColums(System.Collections.Generic.IList<Column> columns)
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
    }
}
