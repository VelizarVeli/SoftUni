using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using SIS.HTTP.Cookies;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.HTTP.Sessions;
using SIS.WebServer.Api;
using SIS.WebServer.Api.Contracts;
using SIS.WebServer.Routing;

namespace SIS.WebServer
{
    public class Server
    {
        private const string LocalhostIpAddress = "127.0.0.1";

        private readonly int port;

        private readonly TcpListener listener;

        private readonly IHttpHandlingContext handlersContext;

        private bool isRunning;

        public Server(int port, IHttpHandlingContext handlersContext)
        {
            this.port = port;
            this.listener = new TcpListener(IPAddress.Parse(LocalhostIpAddress), port);

            this.handlersContext = handlersContext;
        }

        public void Run()
        {
            this.listener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server started at http://{LocalhostIpAddress}:{this.port}");
            while (isRunning)
            {
                var client = listener.AcceptSocketAsync().GetAwaiter().GetResult();

                Task.Run(() => Listen(client));
            }
        }

        public async void Listen(Socket client)
        {
            var connectionHandler = new ConnectionHandler(client, this.handlersContext);
            await connectionHandler.ProcessRequestAsync();
        }

    }
}
