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
        public string DisplayName;
        public string Name;
        public string User;
        public string Password;
        public bool IsOpen;
        public List<DataSet> Schemas;
    }
}
