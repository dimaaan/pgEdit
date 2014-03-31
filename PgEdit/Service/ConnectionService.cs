using Npgsql;
using PgEdit.Domain;
using Renci.SshNet;

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace PgEdit.Service
{
    public static class ConnectionService
    {
        private const string CONNECTION_STRINGS_PATH = "ConnectionStrings.json";

        public static List<Server> ConvertSettingsToDomain(ConnectionSettings settings)
        {
            return (
                    from serv in settings.servers
                    select new Server()
                    {
                        Address = serv.address,
                        Port = serv.port,
                        Ssh = serv.ssh != null ?
                        new SshTunnel()
                        {
                            Server = serv.ssh.server,
                            Port = serv.ssh.port,
                            User = serv.ssh.user,
                            Password = serv.ssh.password,
                            KeyFilePath = serv.ssh.keyFilePath
                        } : null,
                        Databases = (from db in serv.databases
                                     select new Database()
                                     {
                                         Name = db.name,
                                         User = db.user,
                                         Password = db.password
                                     }
                                    ).ToList()
                    }).ToList();
        }

        public static ConnectionSettings ConvertDomainToSettings(List<Server> servers) 
        {
            return new ConnectionSettings() {
                servers = (from serv in servers
                    select new ConnectionSettings.Server()
                    {
                        address = serv.Address,
                        port = serv.Port,
                        ssh = serv.Ssh != null ?
                        new ConnectionSettings.Server.Ssh()
                        {
                            server = serv.Ssh.Server,
                            port = serv.Ssh.Port,
                            user = serv.Ssh.User,
                            password = serv.Ssh.Password,
                            keyFilePath = serv.Ssh.KeyFilePath
                        } : null,
                        databases = (from db in serv.Databases
                                     select new ConnectionSettings.Server.Database()
                                     {
                                         name = db.Name,
                                         user = db.User,
                                         password = db.Password
                                     }).ToList()
                    }).ToList()
            };
        }

        public static Universe Load()
        {
            const string CONNECTION_STRINGS_PATH = "ConnectionStrings.json";
            Universe universe = new Universe();

            if (File.Exists(CONNECTION_STRINGS_PATH))
            {
                string json = File.ReadAllText(CONNECTION_STRINGS_PATH);
                ConnectionSettings settings = JsonConvert.DeserializeObject<ConnectionSettings>(json);
                universe.Servers = ConvertSettingsToDomain(settings);
            }

            return universe;
        }

        public static void Save(Universe universe)
        {
            ConnectionSettings settings = ConvertDomainToSettings(universe.Servers);
            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            using (StreamWriter sw = new StreamWriter(CONNECTION_STRINGS_PATH, false))
            {
                sw.Write(json);
            }
        }

        /// <summary>
        /// When adding new server, servers with same host, port and SSH settings will be merged to avoid dublicates
        /// </summary>
        public static void MergeServer(List<Server> servers, Server server)
        {
            bool merged = false;

            foreach (Server currServ in servers)
            {
                if (currServ.Address == server.Address && currServ.Port == server.Port)
                {
                    if ((currServ.Ssh == null) == (server.Ssh == null))
                    {
                        if (currServ.Ssh != null)
                        {
                            if(currServ.Ssh.Server == server.Ssh.Server &&
                                currServ.Ssh.Port == server.Ssh.Port &&
                                currServ.Ssh.User == server.Ssh.User &&
                                currServ.Ssh.Password == server.Ssh.Password &&
                                currServ.Ssh.KeyFilePath == server.Ssh.KeyFilePath)
                            {
                                merged = true;
                            }
                        }
                        else
                        {
                            merged = true;
                        }
                    }

                    if (merged)
                    {
                        currServ.Databases.AddRange(server.Databases);
                        break;
                    }
                }
            }

            if (!merged)
            {
                servers.Add(server);
            }
        }

        private static int FreePort()
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0)); // 0 means ask OS to allocate free port
            return ((IPEndPoint)sock.LocalEndPoint).Port;
        }

        public static void CreateSSHTunnel(Server server)
        {
            if (server.Ssh.KeyFilePath != null)
            {
                using (var stream = new FileStream(server.Ssh.KeyFilePath, FileMode.Open, FileAccess.Read))
                {
                    var privateKeyFile = new PrivateKeyFile(stream, server.Ssh.Password);
                    var authenticationMethod = new PrivateKeyAuthenticationMethod(server.Ssh.User, privateKeyFile);
                    var connectionInfo = new ConnectionInfo(server.Ssh.Server, server.Ssh.Port, server.Ssh.User, authenticationMethod);

                    server.Ssh.Client = new SshClient(connectionInfo);
                }
            }
            else
            {
                server.Ssh.Client = new SshClient(server.Ssh.Server, server.Ssh.Port, server.Ssh.User, server.Ssh.Password);
            }

            server.Ssh.Client.Connect();
            server.Ssh.ForwardedPort = FreePort();

            var forwardedPort = new ForwardedPortLocal("localhost", (uint)server.Ssh.ForwardedPort, server.Address, server.Port);

            server.Ssh.Client.AddForwardedPort(forwardedPort);
            forwardedPort.Start();
        }

        public static void CloseSshTunnel(Server server)
        {
            if (server.Ssh != null && server.Ssh.Client != null)
            {
                foreach (var port in server.Ssh.Client.ForwardedPorts)
                {
                    port.Stop();
                }
                server.Ssh.Client.Disconnect();
            }
        }

        public static NpgsqlConnection GetConnection(Server server, Database db)
        {
            string connStr = "Server={0};Port={1};User Id={2};Password={3};Database={4};";

            if (server.Ssh != null)
            {
                if (server.Ssh.Client == null)
                {
                    ConnectionService.CreateSSHTunnel(server);
                }

                connStr = string.Format(connStr, "localhost", server.Ssh.ForwardedPort, db.User, db.Password, db.Name);
            }
            else
            {
                connStr = string.Format(connStr, server.Address, server.Port, db.User, db.Password, db.Name);
            }

            return new NpgsqlConnection(connStr);
        }

    }
}