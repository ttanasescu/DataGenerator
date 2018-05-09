using System;
using System.Linq;
using System.Windows.Forms;
using DataGeneratorLibrary.DAL;

namespace DataGeneratorGUI.Forms
{
    public partial class SelectTableForm : Form
    {
        private readonly Dal _dal;
        public string DataBase { get; set; }
        public string TableName { get; set; }
        public string ServerName { get; set; }

        public SelectTableForm()
        {
            _dal = Dal.Instance;
            InitializeComponent();
        }

        private void SelectTableForm_Load(object sender, EventArgs e)
        {
            treeView1.BeforeExpand += OnBeforeExpand;
            treeView1.NodeMouseDoubleClick += OnNodeMouseDoubleClick;

            var root = new TreeNode(ServerName);
            treeView1.Nodes.Add(root);

            var databases = _dal.GetDataBases();
            foreach (var database in databases)
            {
                var node = new TreeNode(database);
                node.Nodes.Add("%dummy%", "%dummy%");
                root.Nodes.Add(node);
            }

            root.Expand();
            if (!string.IsNullOrEmpty(DataBase))
            {
                foreach (TreeNode o in root.Nodes)
                {
                    if (o.Text == DataBase)
                    {
                        o.Expand();
                    }
                }
                
            }
        }

        void OnBeforeExpand(object o, TreeViewCancelEventArgs args)
        {
            var node = args.Node;
            if (node.Nodes.ContainsKey("%dummy%"))
            {
                node.Nodes.RemoveByKey("%dummy%");
                _dal.SqlConnectionStringBuilder.InitialCatalog = node.Text;
                var tables = _dal.GetTables().OrderBy(s => s);
                foreach (var table in tables)
                {
                    node.Nodes.Add(table, table);
                }
            }
        }

        private void OnNodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (sender is TreeView treeView)
            {
                var node = treeView.SelectedNode;
                if (node.Level == 2)
                {
                    DataBase = node.Parent.Text;
                    TableName = node.Text;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
