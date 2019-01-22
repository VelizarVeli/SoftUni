using System;
using System.Linq;
using System.Reflection;
using TheTankGame.Entities.Parts.Contracts;
using TheTankGame.Entities.Parts.Factories.Contracts;

namespace TheTankGame.Entities.Parts.Factories
{
    public class PartFactory : IPartFactory
    {
        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            var allTypes = Assembly.GetCallingAssembly().GetTypes();

            var parType = allTypes
                .Where(t => typeof(IPart).IsAssignableFrom(t))
                .FirstOrDefault(t => t.Name == partType);

            var part = (IPart)Activator.CreateInstance(parType, new object[] { partType, model, weight, price, additionalParameter });

            return part;
        }
    }
}
