using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses;
using SIS.HTTP.Responses.Contracts;
using SIS.WebServer.Routing;

namespace SIS.WebServer
{
    public class ConnectionHandler
    {
        private readonly Socket _client;

        private readonly ServerRoutingTable _serverRoutingTable;

        public ConnectionHandler(Socket client, ServerRoutingTable serverRoutingTable)
        {
            _client = client;
            _serverRoutingTable = serverRoutingTable;
        }

        private async Task<IHttpRequest> ReadRequest()
        {
            var result = new StringBuilder();
            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                var numberOfBytesRead = await _client.ReceiveAsync(data.Array, SocketFlags.None);

                if (numberOfBytesRead == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesRead);
                result.Append(bytesAsString);

                if (numberOfBytesRead < 1023)
                {
                    break;
                }
            }

            return result.Length == 0 ? null : new HttpRequest(result.ToString());
        }

        private IHttpResponse HandleRequest(IHttpRequest request)
        {
            if (!_serverRoutingTable.Routes.ContainsKey(request.RequestMethod) ||
                !_serverRoutingTable.Routes[request.RequestMethod].ContainsKey(request.Path))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            return _serverRoutingTable.Routes[request.RequestMethod][request.Path].Invoke(request);
        }

        private async Task PrepareResponse(IHttpResponse httpResponse)
        {
            byte[] byteSegments = httpResponse.GetBytes();
            var sting = Encoding.UTF8.GetString(byteSegments);
            await _client.SendAsync(byteSegments, SocketFlags.None);
        }

        public async Task ProcessRequestAsync()
        {
            var request = await ReadRequest();

            if (request != null)
            {
                var response = HandleRequest(request);
                await PrepareResponse(response);
            }

            _client.Shutdown(SocketShutdown.Both);
        }
    }
}
