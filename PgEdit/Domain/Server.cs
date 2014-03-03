using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgEdit.Domain
{
    public class Server
    {
        public string Address;
        public string Port;
        public List<Database> Databases;
    }
}
