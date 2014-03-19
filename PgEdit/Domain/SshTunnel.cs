using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgEdit.Domain
{
    public class SshTunnel
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string KeyFilePath { get; set; }
        public int ForwardedPort { get; set; }
        public SshClient Client { get; set; }

        public SshTunnel()
        {
            Server = "localhost";
            Port = 22;
        }
    }
}
