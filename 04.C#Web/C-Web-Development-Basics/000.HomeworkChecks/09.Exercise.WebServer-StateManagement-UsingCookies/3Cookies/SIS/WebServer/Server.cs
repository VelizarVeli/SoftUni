using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebServer.Routing;

namespace WebServer
{
    public class Server
    {
        private const string LocalHostIPAddres = "127.0.0.1";
        private readonly int port;
        private readonly TcpListener listener;
        private readonly ServerRoutingTable serverRoutingTable;
        private bool isRunnign;

        public Server(int port, ServerRoutingTable serverRoutingTable)
        {
            this.port = port;
            this.listener = new TcpListener(IPAddress.Parse(LocalHostIPAddres), port);

            this.serverRoutingTable = serverRoutingTable;
        }

        public void Run()
        {
            this.listener.Start();
            this.isRunnign = true;

            Console.WriteLine($"Server started at http://{LocalHostIPAddres}:{port}");
            var task = Task.Run(this.ListenLoop);

            task.Wait();
        }

        public async Task ListenLoop()
        {
            while (isRunnign)
            {
                var client = await this.listener.AcceptSocketAsync();
                var connectionHandler = new ConnectionHandler(client, this.serverRoutingTable);
                var responseTask = connectionHandler.ProcessRequestAsync();
                responseTask.Wait();
                
            }
        }

        
    }
}
