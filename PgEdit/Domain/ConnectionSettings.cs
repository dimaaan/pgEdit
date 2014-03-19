using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgEdit.Domain
{
    /// <summary>
    /// DTO to persisnt connection settings like connection string, ssh settings, etc
    /// </summary>
    public class ConnectionSettings
    {
        public class Server
        {
            public class Database
            {
                public string name;
                public string user;
                public string password;
            }

            public class Ssh
            {
                public string server;
                public int port;
                public string user;
                public string password;
                public string keyFilePath;
            }

            public string address;
            public uint port;
            public Ssh ssh;
            public List<Database> databases;
        }

        public List<Server> servers;
    }
}
