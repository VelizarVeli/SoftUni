using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoftuniHttpServer
{
    public class HttpServer : IHttpServer
    {
        private bool IsWorking;

        private readonly TcpListener tcpListener;
        private readonly RequestProcessor requestProcessor;

        public HttpServer()
        {
            this.tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 80);
            
            this.requestProcessor = new RequestProcessor();
        }

        public void Start()
        {
            this.tcpListener.Start();
            this.IsWorking = true;
            Console.WriteLine("Started...");
            while (this.IsWorking)
            {
                var client = this.tcpListener.AcceptTcpClient();
                    requestProcessor.ProcessClient(client);
            }
        }

         public void Stop()
        {
            this.IsWorking = false;
        }
    }

    public class RequestProcessor
    {
        public async Task ProcessClient(TcpClient client)
        {
            var buffer = new byte[10240];
            var stream = client.GetStream();
            var readLength = await stream.ReadAsync(buffer, 0, buffer.Length);
            var requestText = Encoding.UTF8.GetString(buffer, 0, readLength);
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(requestText);
            var responseText = File.ReadAllText("Index.html");
            var responseBytes = Encoding.UTF8.GetBytes(
                "HTTP/1.0 200 OK" + Environment.NewLine +
                "Content-Type: text/html" + Environment.NewLine + 
                "Set-Cookie: cookie=OK; Path=/users" + Environment.NewLine +
                "Content-Length: 0" + responseText.Length + Environment.NewLine + Environment.NewLine + responseText);
            await stream.WriteAsync(responseBytes);
        }
    }

}