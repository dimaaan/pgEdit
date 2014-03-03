using Npgsql;
using PgEdit.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PgEdit.Service
{
    public static class TreeService
    {
        public static List<TreeNode> ConvertSettingsToTreeNodes(Universe universe)
        {
            List<TreeNode> nodes = new List<TreeNode>();

            foreach (Server server in universe.Servers)
            {
                TreeNode nodeHost = new TreeNode()
                {
                    Text = server.Address,
                    Tag = server
                };
                nodes.Add(nodeHost);

                foreach (Database db in server.Databases)
                {
                    TreeNode nodeDB = new TreeNode()
                    {
                        Text = db.DisplayName,
                        Tag = db
                    };
                    nodeHost.Nodes.Add(nodeDB);
                }
            }

            return nodes;
        }

        public static List<TreeNode> ConvertDBSchemaToTreeNodes(Database db)
        {
            List<TreeNode> schemaNodes = new List<TreeNode>();

            foreach (DataSet schema in db.Schemas)
            {
                TreeNode schemaNode = new TreeNode()
                {
                    Text = schema.DataSetName,
                    Tag = schema
                };
                schemaNodes.Add(schemaNode);

                foreach (DataTable table in schema.Tables)
                {
                    TreeNode tableNode = new TreeNode()
                    {
                        Text = table.TableName,
                        Tag = table
                    };

                    schemaNode.Nodes.Add(tableNode);
                }
            }

            return schemaNodes;
        }

        public static NpgsqlConnection GetConnection(TreeNode node)
        {
            string connStr;

            if (node.Tag is DataTable || node.Tag is DataSet)
            {
                return GetConnection(node.Parent);
            }
            else if (node.Tag is Database)
            {
                Database db = (Database)node.Tag;
                Server server = (Server)node.Parent.Tag;
                connStr = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};", server.Address, server.Port, db.User, db.Password, db.Name);
            }
            else
            {
                throw new InvalidOperationException("Trying to get connection without specifying database");
            }

            return new NpgsqlConnection(connStr);
        }
    }
}
