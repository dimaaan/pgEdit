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
        public string Address;
        public uint Port;
        public List<Database> Databases;
        public SSHTunnelInfo Ssh;
        public SshClient sshClient;
    }
}
