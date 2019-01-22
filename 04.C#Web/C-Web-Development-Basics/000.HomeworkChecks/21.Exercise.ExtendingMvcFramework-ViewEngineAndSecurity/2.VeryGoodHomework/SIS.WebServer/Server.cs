using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using SIS.HTTP.Sessions.Contracts;
using SIS.Services.Contracts;
using SIS.WebServer.Common;
using SIS.WebServer.Contracts;

namespace SIS.WebServer
{
    public class Server : IServer
    {
	private IPHostEntry Host => Dns.GetHostEntry(Constants.LocalHostName);
	private IPAddress IPAddress => Host.AddressList
	    .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
	    .FirstOrDefault();
	private readonly IServiceCollection services;
	private readonly IHttpSessionStorage sessions;
	private readonly TcpListener listener;
	private readonly int port;
	private HashSet<string> uniqueConnections;

	private bool IsRunning => listener.Server.IsBound;

	public Server(int port, IServiceCollection services)
	{
	    this.port = port;
	    this.services = services;
	    sessions = services.GetService<IHttpSessionStorage>();
	    listener = new TcpListener(IPAddress, port);
	    uniqueConnections = new HashSet<string>();
	}

	public void Run()
	{
	    try
	    {
		listener.Start();
		Uri.TryCreate($"{Uri.UriSchemeHttp}://{listener.LocalEndpoint}",
		    UriKind.RelativeOrAbsolute, out Uri serverUrl);
		Console.WriteLine($"Server started at {serverUrl.OriginalString}");
		TryOpenBrowser(serverUrl.OriginalString);
		Console.WriteLine("Awaiting client connections...");
		Task listenTask = Task.Run(ListenLoopAsync);
		listenTask.Wait();
	    }
	    catch (Exception exception)
	    {
		if (exception.InnerException != null)
		{
		    Console.WriteLine(exception.InnerException.Message);
		}
		else Console.WriteLine(exception.Message);
	    }
	}

	private void TryOpenBrowser(string url)
	{
	    try { Process.Start(url); }
	    catch
	    {
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
		    url = url.Replace("&", "^&");
		    Process.Start(new ProcessStartInfo(
			Constants.WindowsCommandPrompt,
			string.Format(Constants.WindowsStartCommand, url)));
		}
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
		    Process.Start(Constants.LinuxOpenCommand, url);
		if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
		    Process.Start(Constants.MacOSOpenCommand, url);
	    }
	}

	private async Task ListenLoopAsync()
	{
	    while (IsRunning)
	    {
		if (listener.Pending())
		{
		    Socket client = await listener.Server.AcceptAsync();
		    var connection = new ConnectionHandler(client, services, sessions);
		    Task responseTask = connection.ProcessRequestAsync();
		    string clientAddress = client.RemoteEndPoint.ToString().Split(':')[0];
		    if (!uniqueConnections.Any(c => c == clientAddress))
		    {
			Console.WriteLine($"Connection established from address {clientAddress}");
			uniqueConnections.Add(clientAddress);
		    }
		    responseTask.Wait();
		}
	    }
	}
    }
}
