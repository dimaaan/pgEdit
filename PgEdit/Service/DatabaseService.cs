using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace PgEdit.Service
{
    public static class DatabaseService
    {
        public static List<DataSet> fetchDatabaseSchema(NpgsqlConnection connection)
        {
            List<DataSet> schemas = fetchSchemas(connection);

            foreach (DataSet schema in schemas)
            {
                DataTable[] tables = fetchTables(connection, schema);
                schema.Tables.AddRange(tables);
            }

            return schemas;
        }

        private static List<DataSet> fetchSchemas(NpgsqlConnection connection)
        {
            string sql = 
                "SELECT schema_name " + 
                "FROM information_schema.schemata " +
                "WHERE schema_name NOT LIKE 'pg_%' AND schema_name != 'information_schema'";
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            List<DataSet> schemas = new List<DataSet>();

            while (reader.Read())
            {
                DataSet schema = new DataSet()
                {
                    DataSetName = reader.GetString(0)
                };

                schemas.Add(schema);
            }

            return schemas;
        }

        private static DataTable[] fetchTables(NpgsqlConnection connection, DataSet schema)
        {
            string sql =
                "SELECT table_name " +
                "FROM information_schema.tables " +
                "WHERE table_schema = '{0}'";
            NpgsqlCommand command = new NpgsqlCommand(String.Format(sql, schema.DataSetName), connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            List<DataTable> tables = new List<DataTable>();

            while (reader.Read())
            {
                DataTable table = new DataTable()
                {
                    TableName = reader.GetString(0)
                };

                tables.Add(table);
            }

            return tables.ToArray();
        }

        public static void fetchTableByName(NpgsqlConnection connection, DataTable table)
        {
            string sql = String.Format("SELECT * FROM {0}.{1}", table.DataSet.DataSetName, table.TableName);
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);

            table.Clear();
            adapter.Fill(table.DataSet, table.TableName);
        }
    }
}
