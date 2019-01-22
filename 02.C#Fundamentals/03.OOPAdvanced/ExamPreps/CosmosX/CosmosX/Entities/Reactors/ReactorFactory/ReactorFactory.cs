using System;
using System.Linq;
using System.Reflection;
using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Reactors.Contracts;
using CosmosX.Entities.Reactors.ReactorFactory.Contracts;

namespace CosmosX.Entities.Reactors.ReactorFactory
{
    public class ReactorFactory : IReactorFactory
    {
        public IReactor CreateReactor(string reactorTypeName, int id, IContainer moduleContainer, int additionalParameter)
        {
            Type type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == reactorTypeName + "Reactor");

            IReactor reactor = (IReactor)Activator.CreateInstance(type, id, moduleContainer, additionalParameter);

            return reactor;
        }
    }
}
