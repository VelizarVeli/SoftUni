using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
namespace SIS.WebServer
{
    using HTTP.Common;
    using HTTP.Exceptions;
    using HTTP.Requests;
    using HTTP.Responses;
    using HTTP.Sessions;
    using Results;
    using Routing;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class ConnectionHandler
    {
        private const string RootDirectoryRelativePath = "";

        private readonly Socket client;

        private readonly ServerRoutingTable serverRoutingTable;

        public ConnectionHandler(
            Socket client,
            ServerRoutingTable serverRoutingTable)
        {
            CoreValidator.ThrowIfNull(client, nameof(client));
            CoreValidator.ThrowIfNull(serverRoutingTable, nameof(serverRoutingTable));

            this.client = client;
            this.serverRoutingTable = serverRoutingTable;
        }

        private async Task<IHttpRequest> ReadRequest()
        {
            var result = new StringBuilder();
            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int numberOfBytesRead = await this.client.ReceiveAsync(data.Array, SocketFlags.None);

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

        private IHttpResponse HandleRequest(IHttpRequest httpRequest)

        {
            bool isResourceRequest = this.IsResourceRequest(httpRequest);

            if (isResourceRequest)
            {
                return this.HandleRequestResponse(httpRequest.Path);
            }

            if (!this.serverRoutingTable.Routes.ContainsKey(httpRequest.RequestMethod)
                || !this.serverRoutingTable.Routes[httpRequest.RequestMethod].ContainsKey(httpRequest.Path))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            return this.serverRoutingTable.Routes[httpRequest.RequestMethod][httpRequest.Path].Invoke(httpRequest);
        }

        private IHttpResponse HandleRequestResponse(string path)
        {
            int indexOfLastDot = path.LastIndexOf(".");
            int indexOfStartOfNameOfResource = path.LastIndexOf("/");

            string resoursePathExtension = path.Substring(indexOfLastDot);

            string resourceName = path.Substring(indexOfStartOfNameOfResource);

            string resoursePath = RootDirectoryRelativePath +
                                    "Resources" +
                                    $"/{resoursePathExtension.Substring(1)}" +
                                    resourceName;
            string asfdf = File.ReadAllText(resoursePath);

            if (!File.Exists(resoursePath))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            byte[] fileContent = File.ReadAllBytes(resoursePath);

            return new InlineResourceResult(fileContent, HttpResponseStatusCode.Ok);
        }

        private bool IsResourceRequest(IHttpRequest httpRequest)
        {
            string resourcePath = httpRequest.Path;
            if (resourcePath.Contains("."))
            {
                string resoursePathExtension = resourcePath.Substring(resourcePath.LastIndexOf("."));

                return GlobalConstants.ResourceExtensions.Contains(resoursePathExtension);
            }

            return false;
        }

        private async Task PrepareResponse(IHttpResponse httpResponse)
        {
            byte[] byteSegments = httpResponse.GetBytes();

            await this.client.SendAsync(byteSegments, SocketFlags.None);
        }

        private string SetRequestSession(IHttpRequest httpRequest)
        {
            string sessionId = null;

            if (httpRequest.Cookies.ContainsCookie(HttpSessionStorage.SessionCookieKey))
            {
                HttpCookie cookie = httpRequest.Cookies.GetCookie(HttpSessionStorage.SessionCookieKey);
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

        private void SetResponseSession(IHttpResponse httpResponse, string sessionId)
        {
            if (sessionId != null)
            {
                httpResponse
                    .AddCookie(new HttpCookie(HttpSessionStorage.SessionCookieKey
                        , sessionId));
            }
        }

        public async Task ProcessRequestAsync()
        {
            try
            {
                IHttpRequest httpRequest = await this.ReadRequest();

                if (httpRequest != null)
                {
                    string sessionId = this.SetRequestSession(httpRequest);

                    IHttpResponse httpResponse = this.HandleRequest(httpRequest);

                    this.SetResponseSession(httpResponse, sessionId);

                    await this.PrepareResponse(httpResponse);
                }
            }
            catch (BadRequestException e)
            {
                await this.PrepareResponse(new TextResult(e.Message, HttpResponseStatusCode.BadRequest));
            }
            catch (Exception e)
            {
                await this.PrepareResponse(new TextResult(e.Message, HttpResponseStatusCode.InternalServerError));
            }

            this.client.Shutdown(SocketShutdown.Both);
        }
    }
}