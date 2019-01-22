namespace SIS.WebServer
{
    using Common;
    using HTTP.Cookies;
    using HTTP.Enums;
    using HTTP.Exceptions;
    using HTTP.Requests;
    using HTTP.Requests.Contracts;
    using HTTP.Responses;
    using HTTP.Responses.Contracts;
    using HTTP.Sessions;
    using Results;
    using Routing;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class ConnectionHandler
    {
        private readonly Socket client;
        private readonly ServerRoutingTable serverRoutingTable;

        public ConnectionHandler(Socket client, ServerRoutingTable serverRoutingTable)
        {
            this.client = client;
            this.serverRoutingTable = serverRoutingTable;
        }

        public async Task ProcessRequestAsync()
        {
            try
            {
                var httpRequest = await this.ReadRequest();
                if (httpRequest != null)
                {
                    var sessionId = this.SetRequestSession(httpRequest);
                    var httpResponse = this.HandleRequest(httpRequest);
                    this.SetResponseSession(httpResponse, sessionId);

                    await this.PrepareResponse(httpResponse);
                }
            }
            catch (BadRequestException exception)
            {
                await this.PrepareResponse(new TextResult(exception.ToString(), HttpResponseStatusCode.BadRequest));
            }
            catch (Exception exception)
            {
                await this.PrepareResponse(new TextResult(exception.ToString(), HttpResponseStatusCode.InternalServerError));
            }

            this.client.Shutdown(SocketShutdown.Both);
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

                var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesRead);
                result.Append(bytesAsString);
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

        private string SetRequestSession(IHttpRequest httpRequest)
        {
            string sessionId = null;
            if (httpRequest.Cookies.ContainsCookie(Constants.SessionCookieKey))
            {
                var cookie = httpRequest.Cookies.GetCookie(Constants.SessionCookieKey);
                sessionId = cookie.Value;
                httpRequest.Session = HttpSessionStorage.GetSession(sessionId);
            }
            else
            {
                sessionId = Guid.NewGuid().ToString();
                httpRequest.Session = HttpSessionStorage.GetSession(sessionId);
            }

            return sessionId;
        }

        private IHttpResponse HandleRequest(IHttpRequest httpRequest)
        {
            if (this.IsResourceRequest(httpRequest.Path))
            {
                return this.HandleRequestResponce(httpRequest.Path);
            }

            if (!this.serverRoutingTable.Routes.ContainsKey(httpRequest.RequestMethod)
            || !this.serverRoutingTable.Routes[httpRequest.RequestMethod].ContainsKey(httpRequest.Path.ToLower()))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            return this.serverRoutingTable.Routes[httpRequest.RequestMethod][httpRequest.Path].Invoke(httpRequest);
        }

        private IHttpResponse HandleRequestResponce(string httpRequestPath)
        {
            var requestPathExtension = httpRequestPath.Substring(httpRequestPath.LastIndexOf('.'));
            var resourceName = httpRequestPath.Substring(httpRequestPath.LastIndexOf('/'));
            var resourcePath = Constants.FolderResourcesRelativePath + requestPathExtension.Substring(1) + resourceName;
            if (!File.Exists(resourcePath))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            var fileContent = File.ReadAllBytes(resourcePath);

            return new InlineResourceResult(fileContent, HttpResponseStatusCode.Ok);
        }

        private bool IsResourceRequest(string httpRequestPath)
        {
            if (httpRequestPath.Contains('.'))
            {
                var requestPathExtension = httpRequestPath.Substring(httpRequestPath.LastIndexOf('.'));
                return Constants.ResourceExtentisons.Contains(requestPathExtension);
            }

            return false; ;
        }

        private void SetResponseSession(IHttpResponse httpResponse, string sessionId)
        {
            if (sessionId != null)
            {
                httpResponse.AddCookie(new HttpCookie(Constants.SessionCookieKey, $"{sessionId}; {Constants.ResponseHttpOnly}"));
            }
        }

        private async Task PrepareResponse(IHttpResponse httpResponse)
        {
            var byteSegments = httpResponse.GetBytes();
            await this.client.SendAsync(byteSegments, SocketFlags.None);
        }
    }
}