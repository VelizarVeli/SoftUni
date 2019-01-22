using TeamBuilder.App.Core;

namespace TeamBuilder.App
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var engine = new Engine(new CommandDispatcher(new AuthenticationManager()));
            engine.Run();
        }
    }
}
