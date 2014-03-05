using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace PgEdit.Service
{
    public static class DatabaseService
    {
        public static List<String> fetchDbNames(NpgsqlConnection connection)
        {
            string sql =
                "SELECT datname " +
                "FROM pg_database " +
                "WHERE datistemplate IS FALSE AND datname != 'postgres' " +
                "ORDER BY datname";
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            List<string> dbs = new List<string>();

            while (reader.Read())
            {
                dbs.Add(reader.GetString(0));
            }

            return dbs;
        }

        public static List<DataSet> fetchAllSchemasWithTables(NpgsqlConnection connection)
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
                "SELECT nspname " +
                "FROM pg_namespace " +
                "WHERE nspname NOT LIKE 'pg_%' AND nspname != 'information_schema' " +
                "ORDER BY nspname";
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
                "WHERE table_schema = @schema " +
                "ORDER BY table_name";
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("schema", schema.DataSetName);

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
