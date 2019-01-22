namespace SoftuniHttpServer
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            IHttpServer server = new HttpServer();

            server.Start();
        }
    }
}
