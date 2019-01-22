using TheTankGame.Entities.Miscellaneous;

namespace TheTankGame.Entities.Vehicles.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Vehicles.Contracts;
    using Contracts;

    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle
            (string vehicleType,string model,double weight,decimal price,int attack,int defense,int hitPoints)
        {
            Type type = Assembly.GetCallingAssembly()
                                .GetTypes()
                                .FirstOrDefault(t => t.Name == vehicleType);

            //"TestVehicle", "Arsenal", 100, 300, 1000, 450, 2000
            IVehicle vehicle = (IVehicle)Activator.CreateInstance(type,model, weight,price,attack,defense,hitPoints, new VehicleAssembler());

            return vehicle;
        }
    }
}