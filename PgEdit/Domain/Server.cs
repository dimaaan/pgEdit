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
        public SshTunnel Ssh { get; set; }
        public SshClient sshClient { get; set; }

        public Server()
        {
            Address = "localhost";
            Port = 5432;
            Databases = new List<Database>();
        }
    }
}
