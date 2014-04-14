using Npgsql;
using PgEdit.Domain;
using System;
using System.Collections.Generic;
using System.Data;

namespace PgEdit.Service
{
    public static class DatabaseService
    {
        public const int ROWS_LIMIT = 1000;

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

        private static void fetchRowsCount(NpgsqlConnection connection, DataTable table)
        {
            string sql = String.Format("SELECT count(*) FROM {0}.{1}", table.DataSet.DataSetName, table.TableName, ROWS_LIMIT);
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            object reqRes = command.ExecuteScalar();
            long rowsCount = Convert.ToInt64(reqRes);

            if (table.ExtendedProperties.Contains(Database.TABLE_PROPERTY_ROWS_COUNT))
            {
                table.ExtendedProperties.Remove(Database.TABLE_PROPERTY_ROWS_COUNT);
            }
            table.ExtendedProperties.Add(Database.TABLE_PROPERTY_ROWS_COUNT, rowsCount);
        }

        public static void fetchTableByName(NpgsqlConnection connection, DataTable table)
        {
            string sql = String.Format("SELECT * FROM {0}.{1} LIMIT {2}", table.DataSet.DataSetName, table.TableName, ROWS_LIMIT);
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);

            table.Clear();
            adapter.Fill(table.DataSet, table.TableName);

            fetchRowsCount(connection, table);
        }

        public static List<Column> fetchTableColumns(NpgsqlConnection connection, string schema, string table)
        {
            string sql =
                "SELECT " +
                "col.attname AS name, " +
                "pg_catalog.format_type(col.atttypid,col.atttypmod) AS type, " +
                "col.attnotnull AS notnull, " +
                "CASE WHEN (SELECT TRUE FROM pg_constraint c WHERE c.conrelid = tbl.oid AND array_length(c.conkey, 1) = 1 AND col.attnum = ANY (c.conkey) AND c.contype = 'p' LIMIT 1) THEN TRUE ELSE FALSE END AS primarykey, " +
                "CASE WHEN (SELECT TRUE FROM pg_constraint c WHERE c.conrelid = tbl.oid AND array_length(c.conkey, 1) = 1 AND col.attnum = ANY (c.conkey) AND c.contype = 'f' LIMIT 1) THEN TRUE ELSE FALSE END AS foreignkey, " +
                "CASE WHEN (SELECT TRUE FROM pg_constraint c WHERE c.conrelid = tbl.oid AND array_length(c.conkey, 1) = 1 AND col.attnum = ANY (c.conkey) AND c.contype = 'u' LIMIT 1) THEN TRUE ELSE FALSE END AS unique, " +
                "CASE WHEN col.atthasdef IS TRUE THEN def_val.adsrc END AS defaultValue, " +
                "col_description(tbl.oid, col.attnum) AS description " +
                "FROM pg_namespace schema " +
                "INNER JOIN pg_class tbl ON schema.oid = tbl.relnamespace " +
                "INNER JOIN pg_attribute col ON tbl.oid = col.attrelid  " +
                "INNER JOIN pg_type t ON t.oid = col.atttypid " +
                "LEFT JOIN pg_attrdef def_val ON def_val.adrelid = tbl.oid AND def_val.adnum = col.attnum " +
                "WHERE " +
                "tbl.relkind = 'r' AND " +
                "schema.nspname = @schema AND " +
                "tbl.relname = @table AND " +
                "col.attnum > 0";
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);

            command.Parameters.AddWithValue("schema", schema);
            command.Parameters.AddWithValue("table", table);

            NpgsqlDataReader reader = command.ExecuteReader();
            List<Column> columns = new List<Column>(64);
            var ordinals = new {
                           name = reader.GetOrdinal("name"),
                           type = reader.GetOrdinal("type"),
                           notnull = reader.GetOrdinal("notnull"),
                           primarykey = reader.GetOrdinal("primarykey"),
                           foreignkey = reader.GetOrdinal("foreignkey"),
                           unique = reader.GetOrdinal("unique"),
                           defaultValue = reader.GetOrdinal("defaultValue"),
                           description = reader.GetOrdinal("description")
                       };

            while (reader.Read())
            {
                Column c = new Column() {
                    Name = reader.GetString(ordinals.name),
                    PgType = reader.GetString(ordinals.type),
                    NotNull = reader.GetBoolean(ordinals.notnull),
                    PrimaryKey = reader.GetBoolean(ordinals.primarykey),
                    ForeignKey = reader.GetBoolean(ordinals.foreignkey),
                    Unique = reader.GetBoolean(ordinals.unique),
                    DefaultValue = reader.GetValue(ordinals.defaultValue),
                    Description = reader.IsDBNull(ordinals.description) ? null : reader.GetString(ordinals.description)
                };
                columns.Add(c);
            }

            return columns;
        }
    }
}
