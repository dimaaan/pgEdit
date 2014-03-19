using Npgsql;
using PgEdit.Domain;
using PgEdit.Properties;
using PgEdit.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PgEdit
{
    public partial class frmMain : Form
    {
        private Universe universe;

        private const string IMAGE_KEY_SERVER = "server";
        private const string IMAGE_KEY_DATABASE_CONNECTED = "dbConnected";
        private const string IMAGE_KEY_DATABASE_DISCONNECTED = "dbDisconnected";
        private const string IMAGE_KEY_SCHEMA = "schema";
        private const string IMAGE_KEY_TABLE = "table";
        private const string IMAGE_KEY_TABLE_OPEN = "table-open";

        public frmMain()
        {
            InitializeComponent();
        }

        private void OpenDatabase(TreeNode dbNode) {
            Database db = (Database)dbNode.Tag;
            Server server = (Server)dbNode.Parent.Tag;

            using (NpgsqlConnection connection = ConnectionService.GetConnection(server, db))
            {
                connection.Open();
                db.Schemas = DatabaseService.fetchAllSchemasWithTables(connection);
                foreach (DataSet schema in db.Schemas)
                {
                    db.Columns[schema.DataSetName] = new Dictionary<string, List<Column>>();
                }
            }

            FillTreeViewWithTables(dbNode);

            
            dbNode.ImageKey = IMAGE_KEY_DATABASE_CONNECTED;
            dbNode.SelectedImageKey = IMAGE_KEY_DATABASE_CONNECTED;
            db.IsOpen = true;
            RefreshMenu();
        }

        private void CloseDatabase(TreeNode dbNode)
        {
            Database db = (Database)dbNode.Tag;

            ucTable.DataSource = null;
            ucTable.Tag = null;
            dgvColumns.DataSource = null;
            db.Schemas = null;
            db.IsOpen = false;
            dbNode.Nodes.Clear();
            dbNode.ImageKey = IMAGE_KEY_DATABASE_DISCONNECTED;
            dbNode.SelectedImageKey = IMAGE_KEY_DATABASE_DISCONNECTED;
            RefreshMenu();
        }

        private void CloseDatabasesOfServer(TreeNode serverNode)
        {
            foreach (TreeNode dbNode in serverNode.Nodes)
            {
                CloseDatabase(dbNode);
            }
        }

        /// <summary>
        /// Return database node by it subnodes
        /// </summary>
        public static TreeNode GetSelectedDBNode(TreeNode node)
        {
            TreeNode res;

            if (node.Tag is Server)
            {
                res = null;
            }
            else if (node.Tag is DataTable || node.Tag is DataSet)
            {
                res = GetSelectedDBNode(node.Parent);
            }
            else if (node.Tag is Database)
            {
                res = node;
            }
            else
            {
                throw new InvalidOperationException("Invalid tree node type: " + node.Tag.GetType().ToString());
            }

            return res;
        }

        public void FillTreeViewOnStartup(Universe universe)
        {
            List<TreeNode> nodes = new List<TreeNode>();

            foreach (Server server in universe.Servers)
            {
                TreeNode nodeHost = ServerToNode(server);
                nodes.Add(nodeHost);
            }

            tvTree.Nodes.AddRange(nodes.ToArray());
            tvTree.ExpandAll();
        }

        private TreeNode ServerToNode(Server server)
        {
            TreeNode nodeHost = new TreeNode()
            {
                Text = server.Address,
                Tag = server,
                ImageKey = IMAGE_KEY_SERVER,
                SelectedImageKey = IMAGE_KEY_SERVER,
                ContextMenuStrip = cmsServer
            };

            foreach (Database db in server.Databases)
            {
                TreeNode nodeDB = new TreeNode()
                {
                    Text = db.Name,
                    Tag = db,
                    ImageKey = IMAGE_KEY_DATABASE_DISCONNECTED,
                    SelectedImageKey = IMAGE_KEY_DATABASE_DISCONNECTED,
                };
                nodeHost.Nodes.Add(nodeDB);
            }
            return nodeHost;
        }

        private void RemoveServer(TreeNode selectedNode)
        {
            string msg = "Настройки подключения к серверу и его базам данных будут удалены.{0}Продолжить?";
            var res = MessageBox.Show(
                String.Format(msg, Environment.NewLine),
                null,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (res == DialogResult.Yes)
            {
                Server server = (Server)selectedNode.Tag;

                SuspendLayout();
                CloseDatabasesOfServer(selectedNode);
                universe.Servers.Remove(server);
                ConnectionService.CloseSshTunnel(server);
                ConnectionService.Save(universe);
                selectedNode.Remove();
                ResumeLayout();
            }
        }

        private void ShowTable(TreeNode node)
        {
            DataTable table = (DataTable)node.Tag;
            TreeNode dbNode = GetSelectedDBNode(node);
            Database db = (Database)dbNode.Tag;
            Server server = (Server)dbNode.Parent.Tag;
            List<Column> columns;

            using (NpgsqlConnection connection = ConnectionService.GetConnection(server, db))
            {
                connection.Open();
                DatabaseService.fetchTableByName(connection, table);
                columns = DatabaseService.fetchTableColumns(connection, table.DataSet.DataSetName, table.TableName);
                db.Columns[table.DataSet.DataSetName][table.TableName] = columns;
            }


            // hilight image of selected table
            TreeNode prevSelected = (TreeNode)ucTable.Tag;
            if (prevSelected != null)
            {
                prevSelected.ImageKey = IMAGE_KEY_TABLE;
                prevSelected.SelectedImageKey = IMAGE_KEY_TABLE;
            }
            node.ImageKey = IMAGE_KEY_TABLE_OPEN;
            node.SelectedImageKey = IMAGE_KEY_TABLE_OPEN;


            dgvColumns.DataSource = columns;
            ucTable.DataSource = table;
            ucTable.Tag = node;
        }

        public static void FillTreeViewWithTables(TreeNode dbNode)
        {
            Database db = (Database)dbNode.Tag;
            List<TreeNode> nodes = new List<TreeNode>();

            foreach (DataSet schema in db.Schemas)
            {
                TreeNode schemaNode = new TreeNode()
                {
                    Text = schema.DataSetName,
                    Tag = schema,
                    ImageKey = IMAGE_KEY_SCHEMA,
                    SelectedImageKey = IMAGE_KEY_SCHEMA
                };
                nodes.Add(schemaNode);

                foreach (DataTable table in schema.Tables)
                {
                    TreeNode tableNode = new TreeNode()
                    {
                        Text = table.TableName,
                        Tag = table,
                        ImageKey = IMAGE_KEY_TABLE,
                        SelectedImageKey = IMAGE_KEY_TABLE
                    };

                    schemaNode.Nodes.Add(tableNode);
                }
            }

            dbNode.Nodes.AddRange(nodes.ToArray());
            dbNode.ExpandAll();
        }

        private void RefreshMenu()
        {
            TreeNode dbNode = GetSelectedDBNode(tvTree.SelectedNode);

            tsmiConnect.Enabled = dbNode != null && !((Database)dbNode.Tag).IsOpen;
            tsmiDisconnect.Enabled = dbNode != null && ((Database)dbNode.Tag).IsOpen;
        }

        private void OnSelectTreeNode(TreeNode node)
        {
            if (node.Tag != null)
            {
                if (node.Tag is Database)
                {
                    Database db = (Database)node.Tag;

                    if (!db.IsOpen)
                    {
                        OpenDatabase(node);
                    }
                }
                else if (node.Tag is DataTable)
                {
                    ShowTable(node);
                }
            }
        }

        private void Shutdown()
        {
            if (universe != null)
            {
                foreach (var server in universe.Servers)
                {
                    ConnectionService.CloseSshTunnel(server);
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Icon = Resources.logo;

            ilTreeView.Images.Add(IMAGE_KEY_SERVER, Resources.computersystemproduct);
            ilTreeView.Images.Add(IMAGE_KEY_DATABASE_CONNECTED, Resources.Database_Active_icon);
            ilTreeView.Images.Add(IMAGE_KEY_DATABASE_DISCONNECTED, Resources.Database_Inactive_icon);
            ilTreeView.Images.Add(IMAGE_KEY_SCHEMA, Resources.Schema_16xLG);
            ilTreeView.Images.Add(IMAGE_KEY_TABLE, Resources.Table_748);
            ilTreeView.Images.Add(IMAGE_KEY_TABLE_OPEN, Resources.Table_748_Opened);

            universe = ConnectionService.Load();

            FillTreeViewOnStartup(universe);
        }

        private void tsmiNewConnection_Click(object sender, EventArgs e)
        {
            frmConnection dlg = new frmConnection();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                universe.Servers.Add(dlg.Server);

                TreeNode serverNode = ServerToNode(dlg.Server);
                tvTree.Nodes.Add(serverNode);
                
                ConnectionService.Save(universe);
            }
        }

        private void tsmiConnect_Click(object sender, EventArgs e)
        {
            OpenDatabase(tvTree.SelectedNode);
        }

        private void tsmiDisconnect_Click(object sender, EventArgs e)
        {
            TreeNode dbNode = GetSelectedDBNode(tvTree.SelectedNode);

            CloseDatabase(dbNode);
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();

            frm.ShowDialog();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmiRegisteredDB_Click(object sender, EventArgs e)
        {
            Process.Start("ConnectionStrings.json");
        }

        private void tsmiBugReport_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/dimaaan/pgEdit/issues/new");
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Shutdown();
        }

        private void tvTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                OnSelectTreeNode(e.Node);
            }
        }

        private void tvTree_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) &&
                tvTree.SelectedNode != null)
            {
                OnSelectTreeNode(tvTree.SelectedNode);
                e.Handled = true;
            }
        }

        private void tvTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshMenu();            
        }

        private void ucTable_DataSourceNeedRefresh()
        {
            TreeNode node = (TreeNode) ucTable.Tag; // selected node

            ShowTable(node);
        }

        private void tsmiRemoveServer_Click(object sender, EventArgs e)
        {
            // due to strane behavior we can't use TreeView.SelectedNode here to find out TreeNode for witch context menu is opened
            var hitTest = tvTree.HitTest(tvTree.PointToClient(new Point(cmsServer.Left, cmsServer.Top)));
            var selectedNode = hitTest.Node;

            if (selectedNode != null)
            {
                RemoveServer(selectedNode);
            }
        }
    }
}
