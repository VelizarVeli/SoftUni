using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using SIS.WebServer.Routing;

namespace SIS.WebServer
{
    public class Server
    {
        private const string LocalHostIpAdress = "127.0.0.1";

        private readonly int port;

        private readonly TcpListener listener;

        private readonly ServerRoutingTable serverRoutingTable;

        private bool isRunning;

        public Server(int port, ServerRoutingTable serverRoutingTable)
        {
            this.port = port;
            this.listener = new TcpListener(IPAddress.Parse(LocalHostIpAdress), this.port);
            this.serverRoutingTable = serverRoutingTable;
        }

        public void Run()
        {
            this.listener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server is runing on http://{LocalHostIpAdress}: {this.port}");

            var task = Task.Run(this.listenLoop);
            task.Wait();
        }

        public async Task listenLoop()
        {
            while (this.isRunning)
            {
                var client = await this.listener.AcceptSocketAsync();
                var conectionHandler = new ConectionHandler(client, serverRoutingTable);
                var responseTask = conectionHandler.ProcessRequestAsync();
                responseTask.Wait();

            }
        }

    }
}