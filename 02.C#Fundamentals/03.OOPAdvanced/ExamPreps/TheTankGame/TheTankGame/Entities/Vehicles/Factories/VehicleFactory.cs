using System;
using System.Linq;
using System.Reflection;
using TheTankGame.Entities.Vehicles.Contracts;
using TheTankGame.Entities.Vehicles.Factories.Contracts;

namespace TheTankGame.Entities.Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string vehicleType, string model, double weight, decimal price, int attack, int defense,
            int hitPoints)
        {
            var vehicleTypes = Assembly.GetCallingAssembly().GetTypes()
                .Where(t => typeof(IVehicle).IsAssignableFrom(t) && !t.IsAbstract)
                .ToArray();

            var oneIitemType = vehicleTypes.FirstOrDefault(t => t.Name == vehicleType);

            var vehicle = (IVehicle)Activator.CreateInstance(oneIitemType);

            return vehicle;
        }
    }
}
