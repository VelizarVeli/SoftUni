namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;
    using System.Reflection;
    using System.Linq;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private string InterpredCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly.GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName + "command");

            ValidateCommand(commandName, commandType);

            MethodInfo method = typeof(IExecutable).GetMethods().First();

            object[] ctorArgs = new object[] { data, this.repository, this.unitFactory };
            object instance = Activator.CreateInstance(commandType, ctorArgs);

            try
            {
                var result = method.Invoke(instance, null).ToString();
                return result;

            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }

        private static void ValidateCommand(string commandName, Type commandType)
        {
            if (commandType == null)
            {
                throw new ArgumentException("Invalid Command!");
            }

            if (!typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new ArgumentException($"{commandName} is Not a Command!");
            }
        }
    }
}