using System;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SIS.HTTP.Cookies;
using SIS.HTTP.Requests;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using SIS.HTTP.Sessions;
using SIS.HTTP.Sessions.Contracts;
using SIS.Services.Contracts;
using SIS.WebServer.Common;
using SIS.WebServer.Contracts;
using SIS.WebServer.Routing.Contracts;

namespace SIS.WebServer
{
    public class ConnectionHandler : IConnectionHandler
    {
	private const int DataBufferSize = 1024;
	private readonly Socket client;
	private readonly IServiceCollection services;
	private IHttpSessionStorage SessionStorage;
	private IControllerRouter ControllerRouter => services.GetService<IControllerRouter>();
	private IResourceRouter ResourceRouter => services.GetService<IResourceRouter>();

	public ConnectionHandler(Socket client, IServiceCollection services, IHttpSessionStorage sessions)
	{
	    this.client = client;
	    this.services = services;
	    SessionStorage = sessions;
	}

	public async Task ProcessRequestAsync()
	{
	    var httpRequest = await ReceiveRequestDataAsync();
	    if (httpRequest != null)
	    {
		SetRequestSession(httpRequest);
		var httpResponse = HandleRequest(httpRequest);
		SetResponseSession(httpRequest, httpResponse);
		await SendResponseDataAsync(httpResponse);
	    }
	    client.Shutdown(SocketShutdown.Both);
	}

	private async Task<bool> IsConnectedAsync(Socket client)
	{
	    bool blockingState = client.Blocking;
	    try
	    {
		var ping = new ArraySegment<byte>(new byte[0]);
		client.Blocking = false;
		await client.SendAsync(ping, SocketFlags.None);
		return true;
	    }
	    catch (SocketException se)
	    {
		if (se.NativeErrorCode.Equals(10035)) return true;
		else return false;
	    }
	    finally { client.Blocking = blockingState; }
	}

	private async Task<IHttpRequest> ReceiveRequestDataAsync()
	{
	    StringBuilder requestString = new StringBuilder();
	    var dataBuffer = new ArraySegment<byte>(new byte[DataBufferSize]);
	    while (true)
	    {
		int bytesReceived = await client.ReceiveAsync(dataBuffer, SocketFlags.None);
		if (bytesReceived == 0) break;
		string data = Encoding.UTF8.GetString(dataBuffer.Array, 0, bytesReceived);
		requestString.Append(data);
		if (bytesReceived < DataBufferSize) break;
	    }
	    if (requestString.Length == 0) return null;
	    var request = new HttpRequest(requestString.ToString());
	    return request;
	}

	private void SetRequestSession(IHttpRequest request)
	{
	    if (!request.Cookies.ContainsCookie(Constants.HttpSessionKey))
	    {
		request.Session = new HttpSession();
		var sessionCookie = new HttpCookie(Constants.HttpSessionKey, request.Session.Id);
		request.Cookies.AddCookie(sessionCookie);
		SessionStorage.AddOrUpdateSession(request.Session);
	    }
	    if (request.Session == null)
	    {
		string sessionId = request.Cookies.GetCookie(Constants.HttpSessionKey).Value;
		request.Session = SessionStorage.GetOrAddSession(sessionId);
	    }
	}

	private IHttpResponse HandleRequest(IHttpRequest request)
	{
	    IHttpResponse response = null;
	    if (IsResourceRequest(request))
	    {
		response = ResourceRouter.Handle(request);
	    }
	    else response = ControllerRouter.Handle(request);
	    return response;
	}

	private bool IsResourceRequest(IHttpRequest request)
	{
	    return Regex.IsMatch(request.Path, Constants.ResourcePattern, RegexOptions.IgnoreCase);
	}

	private void SetResponseSession(IHttpRequest request, IHttpResponse response)
	{
	    response.Session = SessionStorage.GetOrAddSession(request.Session.Id);
	    var sessionCookie = request.Cookies.GetCookie(Constants.HttpSessionKey);
	    response.Cookies.SetCookie(sessionCookie);
	}

	private async Task SendResponseDataAsync(IHttpResponse response)
	{
	    byte[] bytesToSend = response.GetBytes();
	    var dataBuffer = new ArraySegment<byte>(bytesToSend);
	    await client.SendAsync(dataBuffer, SocketFlags.None);
	}
    }
}
