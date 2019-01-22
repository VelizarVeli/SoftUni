using System;

namespace TeamBuilder.App
{
  public  class Engine
  {
      private readonly CommandDispatcher dispatcher;

      public Engine(CommandDispatcher dispatcher)
      {
          this.dispatcher = dispatcher;
      }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    Console.WriteLine(this.dispatcher.Dispatch(input));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.GetBaseException().Message);
                }
            }
        }
    }
}
