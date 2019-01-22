namespace SIS.WebServer
{
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using Api;
    using HTTP.Common;
    using HTTP.Cookies;
    using HTTP.Requests;
    using HTTP.Requests.Contracts;
    using HTTP.Responses.Contracts;
    using HTTP.Sessions;

    public class ConnectionHandler
    {
        private readonly Socket client;
        private readonly IHttpHandler handler;
        private readonly IHttpHandler resourceHandler;

        public ConnectionHandler(Socket client, IHttpHandler handler, IHttpHandler resourceHandler)
        {
            CoreValidator.ThrowIfNull(client, nameof(client));
            CoreValidator.ThrowIfNull(handler, nameof(handler));
            CoreValidator.ThrowIfNull(resourceHandler, nameof(resourceHandler));

            this.client = client;
            this.handler = handler;
            this.resourceHandler = resourceHandler;
        }

        private async Task<IHttpRequest> ReadRequest()
        {
            var result = new StringBuilder();
            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                var numberOfBytesRead = await this.client.ReceiveAsync(data.Array, SocketFlags.None);
                if (numberOfBytesRead == 0)
                {
                    break;
                }

                var byteAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesRead);
                result.Append(byteAsString);
                if (numberOfBytesRead < 1023)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }

            return new HttpRequest(result.ToString());
        }

        private async Task PrepareResponse(IHttpResponse httpResponse)
        {
            var byteSegments = httpResponse.GetBytes();
            await this.client.SendAsync(byteSegments, SocketFlags.None);
        }

        public async Task ProcessRequestAsync()
        {
            var request = await this.ReadRequest();

            if (request != null)
            {
                var sessionId = this.SetRequestSession(request);
                IHttpResponse response = null;
                if (request.Path.Contains("."))
                {
                    response = this.resourceHandler.Handle(request);
                }
                else
                {
                    response = this.handler.Handle(request);
                }

                this.SetResponseSession(response, sessionId);
                await this.PrepareResponse(response);
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private string SetRequestSession(IHttpRequest request)
        {
            string sessionId = null;

            if (request.Cookies.ContainsCookie(HttpSessionStorage.SessionCookieKey))
            {
                var cookie = request.Cookies.GetCookie(HttpSessionStorage.SessionCookieKey);
                sessionId = cookie.Value;
                request.Session = HttpSessionStorage.GetSession(sessionId);
            }
            else
            {
                sessionId = Guid.NewGuid().ToString();
                request.Session = HttpSessionStorage.GetSession(sessionId);
            }

            return sessionId;
        }

        private void SetResponseSession(IHttpResponse response, string sessionId)
        {
            if (sessionId != null)
            {
                response.AddCookie(new HttpCookie(HttpSessionStorage.SessionCookieKey, $"{sessionId}; HttpOnly"));
            }
        }
    }
}