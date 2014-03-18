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

        public string Name { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool IsOpen { get; set; }

        /// <summary>
        /// DataSet.DataSetName = schema name
        /// DataTable.TableName = table name
        /// </summary>
        public List<DataSet> Schemas { get; set; }

        /// <summary>
        /// Table structure.
        /// First key - schema.
        /// Second key - table
        /// </summary>
        public Dictionary<string, Dictionary<string, List<Column>>> Columns { get; set; }

        public Database()
        {
            Columns = new Dictionary<string, Dictionary<string, List<Column>>>();
        }
    }
}
