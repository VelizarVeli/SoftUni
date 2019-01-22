using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using SIS.HTTP.Cookies;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.HTTP.Sessions;
using SIS.WebServer.Api;
using SIS.WebServer.Routing;

namespace SIS.WebServer
{
    public class Server
    {
        private const string LocalhostIpAddress = "127.0.0.1";

        private readonly int port;

        private readonly TcpListener listener;

        private readonly IHttpHandler httpHandler;

        private readonly IHttpHandler resourceHandler;

        private bool isRunning;

        public Server(int port, IHttpHandler handler, IHttpHandler resourceHandler)
        {
            this.port = port;
            this.listener = new TcpListener(IPAddress.Parse(LocalhostIpAddress), port);

            this.httpHandler = handler;
            this.resourceHandler = resourceHandler;
        }

        

        public void Run()
        {
            this.listener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server started at http://{LocalhostIpAddress} : {port}");

            var task = Task.Run(this.ListenLoop);
            task.Wait();
        }

        public async Task ListenLoop()
        {
            while (this.isRunning)
            {
                var client = await this.listener.AcceptSocketAsync();
                var connectionHandler = new ConnectionHandler(client, this.httpHandler, this.resourceHandler);
                var responseTask = connectionHandler.ProcessRequestAsync();
                responseTask.Wait();
            }
        }

        
    }
}
