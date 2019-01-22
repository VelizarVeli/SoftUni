namespace _03BarracksFactory.Core
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly.GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName + "command");

            ValidateCommand(commandName, commandType);

            FieldInfo[] fildsToInject = commandType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute)))
                .ToArray();

            object[] injectArgs = fildsToInject.Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();

            object[] ctorArgs = new object[] { data }.Concat(injectArgs).ToArray();
            IExecutable instance = (IExecutable)Activator.CreateInstance(commandType, ctorArgs);

            return instance;
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