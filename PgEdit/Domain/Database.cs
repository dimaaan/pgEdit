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

        public string Name;
        public string User;
        public string Password;
        public bool IsOpen;

        /// <summary>
        /// DataSet.DataSetName = schema name
        /// DataTable.TableName = table name
        /// </summary>
        public List<DataSet> Schemas;

        /// <summary>
        /// Table structure.
        /// First key - schema.
        /// Second key - table
        /// </summary>
        public Dictionary<string, Dictionary<string, DataTable>> Columns = new Dictionary<string, Dictionary<string, DataTable>>();
    }
}
