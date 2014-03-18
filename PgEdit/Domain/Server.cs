using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgEdit.Domain
{
    public class Server
    {
        public string Address { get; set; }
        public uint Port { get; set; }
        public List<Database> Databases { get; set; }
        public SSHTunnelInfo Ssh { get; set; }
        public SshClient sshClient { get; set; }

        public Server()
        {
            Port = 5432;
        }
    }
}
