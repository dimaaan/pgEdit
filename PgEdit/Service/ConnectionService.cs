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

        public static uint CreateSSHTunnel(Server server)
        {
            SSHTunnelInfo tunnel = server.Ssh;

            if (tunnel.KeyFilePath != null)
            {
                using (var stream = new FileStream(tunnel.KeyFilePath, FileMode.Open, FileAccess.Read))
                {
                    var privateKeyFile = new PrivateKeyFile(stream);
                    var authenticationMethod = new PrivateKeyAuthenticationMethod(tunnel.User, privateKeyFile);
                    var connectionInfo = new ConnectionInfo(tunnel.Server, tunnel.Port, tunnel.User, authenticationMethod);

                    server.sshClient = new SshClient(connectionInfo);
                }
            }
            else
            {
                server.sshClient = new SshClient(tunnel.Server, tunnel.Port, tunnel.User, tunnel.Password);
            }

            server.sshClient.Connect();

            ForwardedPortLocal forwardedPort = new ForwardedPortLocal("localhost", 0, "localhost", server.Port);

            server.sshClient.AddForwardedPort(forwardedPort);
            forwardedPort.Start();

            return forwardedPort.Port;
        }

        public static NpgsqlConnection GetConnection(Server server, Database db)
        {
            string connStr = "Server={0};Port={1};User Id={2};Password={3};Database={4};";

            if (server.Ssh != null && server.sshClient == null)
            {
                uint forwardedPort = ConnectionService.CreateSSHTunnel(server);
                connStr = string.Format(connStr, server.Address, forwardedPort, db.User, db.Password, db.Name);
            }
            else {
                connStr = string.Format(connStr, server.Address, server.Port, db.User, db.Password, db.Name);
            }

            return new NpgsqlConnection(connStr);
        }
        
    }
}
