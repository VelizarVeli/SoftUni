namespace TheTankGame.Entities.Parts.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Parts.Contracts;

    public class PartFactory : IPartFactory
    {
        private const string PartNameSuffix = "Part";

        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            Type type = Assembly.GetCallingAssembly()
                                .GetTypes()
                                .FirstOrDefault(t => t.Name == partType + PartNameSuffix);


            var constructorInfo = type.GetConstructors();



            IPart part = (IPart)Activator.CreateInstance(type, model, weight, price, additionalParameter);

            return part;
        }
    }
}