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
            string sql = String.Format("SELECT * FROM {0}.{1}", table.DataSet.DataSetName, table.TableName); // TODO set via params
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);

            table.Clear();
            adapter.Fill(table.DataSet, table.TableName);
        }

        public static DataTable fetchTableColumns(NpgsqlConnection connection, string schema, string table)
        {
            // TODO bug on table permissions dublicate rows
            // TODO not working: foreign key, unique key, description
            // TODO union primary and foreign key column in grid
            string sql =
                "SELECT " +
                "f.attname AS name, " +
                "f.attnotnull AS notnull, " +
                "pg_catalog.format_type(f.atttypid,f.atttypmod) AS type, " +
                "CASE WHEN p.contype = 'p' THEN TRUE ELSE FALSE END AS primarykey, " +
                "CASE WHEN p.contype = 'u' THEN TRUE ELSE FALSE END AS uniquekey, " +
                "CASE WHEN p.contype = 'f' THEN g.relname END AS foreignkey, " +
                "CASE WHEN p.contype = 'f' THEN p.confkey END AS foreignkey_fieldnum, " +
                "CASE WHEN p.contype = 'f' THEN g.relname END AS foreignkey, " +
                "CASE WHEN p.contype = 'f' THEN p.conkey END AS foreignkey_connnum, " +
                "CASE WHEN f.atthasdef = 't' THEN d.adsrc END AS default " +
                "FROM pg_attribute f " +
                "JOIN pg_class c ON c.oid = f.attrelid " +
                "JOIN pg_type t ON t.oid = f.atttypid " +
                "LEFT JOIN pg_attrdef d ON d.adrelid = c.oid AND d.adnum = f.attnum " +
                "LEFT JOIN pg_namespace n ON n.oid = c.relnamespace " +
                "LEFT JOIN pg_constraint p ON p.conrelid = c.oid AND f.attnum = ANY (p.conkey) " +
                "LEFT JOIN pg_class AS g ON p.confrelid = g.oid " +
                "WHERE " +
                "c.relkind = 'r' " +
                "AND n.nspname = @schema " +
                "AND c.relname = @table " +
                "AND f.attnum > 0 ";
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);

            command.Parameters.AddWithValue("schema", schema);
            command.Parameters.AddWithValue("table", table);
            
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
            DataTable resultTable = new DataTable();

            adapter.Fill(resultTable);

            resultTable.TableName = table;
            resultTable.Namespace = "columns";

            return resultTable;
        }
    }
}
