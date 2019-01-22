namespace SIS.WebServer
{
    using Api;
    using Api.Contracts;
    using Routing;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    public class Server
    {
        public const string LocalHostIpAddress = "127.0.0.1";

        private readonly int port;

        private readonly TcpListener listener;

        private readonly IHttpHandlersContext handlers;

        private bool isRunning;

        public Server(int port, IHttpHandlersContext handlers)
        {
            this.port = port;
            this.listener = new TcpListener(IPAddress.Parse(LocalHostIpAddress), this.port);

            this.handlers = handlers;
        }

        public void Run()
        {
            this.listener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server started at http://{LocalHostIpAddress}:{this.port}");

            while (isRunning)
            {
                Console.WriteLine("Waiting for client...");

                Socket client = this.listener
                    .AcceptSocketAsync()
                    .GetAwaiter()
                    .GetResult();

                Task.Run(() => this.Listen(client));
            }
        }
        
        public async Task Listen(Socket client)
            => await new ConnectionHandler(client, this.handlers).ProcessRequestAsync();
    }
}
