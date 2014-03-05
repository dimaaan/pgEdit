using Npgsql;
using PgEdit.Domain;
using Renci.SshNet;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Web.Script.Serialization;

namespace PgEdit.Service
{
    public static class ConnectionService
    {
        public static Universe Load()
        {
            const string CONNECTION_STRINGS_PATH = "ConnectionStrings.json";
            Universe universe = new Universe();

            if (File.Exists(CONNECTION_STRINGS_PATH))
            {
                universe = (new JavaScriptSerializer()).Deserialize<Universe>(File.ReadAllText(CONNECTION_STRINGS_PATH));
            }

            return universe;
        }

        private static int FreePort()
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0)); // 0 means ask OS to allocate free port
            return ((IPEndPoint)sock.LocalEndPoint).Port;
        }

        public static uint CreateSSHTunnel(Server server)
        {
            if (server.Ssh.KeyFilePath != null)
            {
                using (var stream = new FileStream(server.Ssh.KeyFilePath, FileMode.Open, FileAccess.Read))
                {
                    var privateKeyFile = new PrivateKeyFile(stream);
                    var authenticationMethod = new PrivateKeyAuthenticationMethod(server.Ssh.User, privateKeyFile);
                    var connectionInfo = new ConnectionInfo(server.Ssh.Server, server.Ssh.Port, server.Ssh.User, authenticationMethod);

                    server.sshClient = new SshClient(connectionInfo);
                }
            }
            else
            {
                server.sshClient = new SshClient(server.Ssh.Server, server.Ssh.Port, server.Ssh.User, server.Ssh.Password);
            }

            server.sshClient.Connect();

            uint freePort = (uint)FreePort();

            var forwardedPort = new ForwardedPortLocal("localhost", freePort, server.Address, server.Port);

            server.sshClient.AddForwardedPort(forwardedPort);
            forwardedPort.Start();

            return freePort;
        }

        public static NpgsqlConnection GetConnection(Server server, Database db)
        {
            string connStr = "Server={0};Port={1};User Id={2};Password={3};Database={4};";

            if (server.Ssh != null && server.sshClient == null)
            {
                uint forwardedPort = ConnectionService.CreateSSHTunnel(server);
                connStr = string.Format(connStr, "localhost", forwardedPort, db.User, db.Password, db.Name);
            }
            else
            {
                connStr = string.Format(connStr, server.Address, server.Port, db.User, db.Password, db.Name);
            }

            return new NpgsqlConnection(connStr);
        }

    }
}