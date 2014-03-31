using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgEdit.Domain
{
    public class Database
    {
        public const string TABLE_PROPERTY_ROWS_COUNT = "rowsCount";
        public const string TABLE_PROPERTY_COLUMNS = "columns";

        public string Name { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool IsOpen { get; set; }

        /// <summary>
        /// DataSet.DataSetName = schema name
        /// DataTable.TableName = table name
        /// </summary>
        public List<DataSet> Schemas { get; set; }

        public Database()
        {
            User = "postgres";
        }
    }
}
