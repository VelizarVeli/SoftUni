namespace SIS.WebServer
{
    using Routing.Contracts;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    public class Server
    {
        private const string LocalHostIpAddress = "127.0.0.1";

        private readonly int port;

        private readonly TcpListener listener;

        private readonly IHttpHandler handlingContext;

        private bool isRunning;

        public Server(int port, IHttpHandler handlingContext)
        {
            this.port = port;
            this.listener = new TcpListener(IPAddress.Parse(LocalHostIpAddress), port);

            this.handlingContext = handlingContext;
        }

        public void Run()
        {
            this.listener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server started at http://{LocalHostIpAddress}:{this.port}");
            while (this.isRunning)
            {
                Console.WriteLine("Waiting for client...");

                var client = this.listener.AcceptSocketAsync().GetAwaiter().GetResult();

                Task.Run(() => this.Listen(client));
            }
        }

        public async void Listen(Socket client)
        {
            var connectionHandler = new ConnectionHandler(client, this.handlingContext);
            await connectionHandler.ProcessRequestAsync();
        }
    }
}