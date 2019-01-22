using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using SIS.WebServer.Routing;

namespace SIS.WebServer
{
    public class Server
    {
        private const string LocalhostIp = "127.0.0.1";

        private readonly int _port;

        private readonly TcpListener _listener;

        private readonly ServerRoutingTable _serverRoutingTable;

        private bool _isRunning;

        public Server(int port, ServerRoutingTable serverRoutingTable)
        {
            _port = port;
            _listener = new TcpListener(IPAddress.Parse(LocalhostIp), _port);
            _serverRoutingTable = serverRoutingTable;
        }

        public void Run()
        {
            _listener.Start();
            _isRunning = true;

            Console.WriteLine($"Server started at http://{LocalhostIp}:{_port}");

            var task = Task.Run(ListenLoop);
            task.Wait();
        }

        public async Task ListenLoop()
        {
            while (_isRunning)
            {
                var client = await _listener.AcceptSocketAsync();
                var connectionHandler = new ConnectionHandler(client, _serverRoutingTable);
                var responseTask = connectionHandler.ProcessRequestAsync();
                responseTask.Wait();
            }
        }
    }
}
