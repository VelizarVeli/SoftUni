using System;
using System.Collections.Generic;
using Logger.Models.Contracts;
using Logger.Models.Factories;

namespace Logger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ILogger logger = InitializeLogger();
            ErrorFactory errorFactory = new ErrorFactory();
            Engine engine = new Engine(logger, errorFactory);
            engine.Run();
        }

        static ILogger InitializeLogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);

            int appenderCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appenderCount; i++)
            {
                string[] args = Console.ReadLine().Split();
                string appenderType = args[0];
                string layoutType = args[1];
                string errorLevel = "INFO";
                if (args.Length == 3)
                {
                    errorLevel = args[2];
                }

                IAppender appender = appenderFactory.CreateAppender(appenderType, errorLevel, layoutType);
                appenders.Add(appender);
            }
            ILogger logger = new Models.Logger(appenders);
            return logger;
        }
    }
}