namespace TheTankGame.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Entities.Parts.Contracts;
    using Entities.Parts.Factories;
    using Entities.Parts.Factories.Contracts;
    using Entities.Vehicles.Contracts;
    using Entities.Vehicles.Factories;
    using Entities.Vehicles.Factories.Contracts;
    using Utils;

    public class TankManager : IManager
    {
        private readonly IDictionary<string, IVehicle> vehicles;
        private readonly IDictionary<string, IPart> parts;
        private readonly IList<string> defeatedVehicles;
        private readonly IBattleOperator battleOperator;
        private readonly IVehicleFactory vehicleFactory;
        private readonly IPartFactory partFactory;

        public TankManager()
        {
            this.vehicles = new Dictionary<string, IVehicle>();
            this.parts = new Dictionary<string, IPart>();
            this.defeatedVehicles = new List<string>();
            this.battleOperator = new TankBattleOperator();
            this.vehicleFactory = new VehicleFactory();
            this.partFactory = new PartFactory();
        }


        public string AddVehicle(IList<string> arguments)
        {
            string vehicleType = arguments[0];
            string model = arguments[1];
            double weight = double.Parse(arguments[2]);
            decimal price = decimal.Parse(arguments[3]);
            int attack = int.Parse(arguments[4]);
            int defense = int.Parse(arguments[5]);
            int hitPoints = int.Parse(arguments[6]);

            IVehicle vehicle = this.vehicleFactory.CreateVehicle(vehicleType, model, weight, price, attack, defense, hitPoints);

            //switch (vehicleType)
            //{
            //    case "Vanguard":
            //        vehicle = new Vanguard(model, weight, price, attack, defense, hitPoints);
            //        break;
            //    case "Revenger":
            //        vehicle = new Revenger(model, weight, price, attack, defense, hitPoints);
            //        break;
            //}

            if (vehicle != null)
            {
                this.vehicles.Add(vehicle.Model, vehicle);
            }

            return string.Format(
                GlobalConstants.VehicleSuccessMessage,
                vehicleType,
                vehicle.Model);
        }

        public string AddPart(IList<string> arguments)
        {
            string vehicleModel = arguments[0];
            string partType = arguments[1];
            string model = arguments[2];
            double weight = double.Parse(arguments[3]);
            decimal price = decimal.Parse(arguments[4]);
            int additionalParameter = int.Parse(arguments[5]);

            IPart part = this.partFactory.CreatePart(
                partType,
                model,
                weight,
                price,
                additionalParameter);

            //IPart part = null;
            //switch (partType)
            //{
            //    case "Arsenal":
            //        part = new ArsenalPart(model, weight, price, additionalParameter);
            //        this.vehicles[vehicleModel].AddArsenalPart(part);
            //        break;
            //    case "Shell":
            //        part = new ShellPart(model, weight, price, additionalParameter);
            //        this.vehicles[vehicleModel].AddShellPart(part);
            //        break;
            //    case "Endurance":
            //        part = new EndurancePart(model, weight, price, additionalParameter);
            //        this.vehicles[vehicleModel].AddEndurancePart(part);
            //        break;
            //}

            if (part != null)
            {
                this.parts.Add(part.Model, part);
                string methodName = "Add" + partType + "Part";
                this.vehicles[vehicleModel].GetType().GetMethod(methodName).Invoke(this.vehicles[vehicleModel], new object[] { part });
            }

            return string.Format(
                GlobalConstants.PartSuccessMessage,
                partType,
                part.Model,
                vehicleModel);
        }

        public string Inspect(IList<string> arguments)
        {
            string model = arguments[0];

            if (this.vehicles.ContainsKey(model))
            {
                return this.vehicles[model].ToString();
            }

            if (this.parts.ContainsKey(model))
            {
                return this.parts[model].ToString();
            }

            return "Bullshit";
        }

        public string Battle(IList<string> arguments)
        {
            string attackerVehicleModel = arguments[0];
            string targetVehicleModel = arguments[1];

            string winnerVehicleModel = this.battleOperator.Battle(this.vehicles[attackerVehicleModel], this.vehicles[targetVehicleModel]);

            if (winnerVehicleModel.Equals(attackerVehicleModel))
            {
                this.vehicles[targetVehicleModel]
                    .Parts
                    .ToList()
                    .ForEach(x => this.parts.Remove(x.Model));

                this.vehicles.Remove(targetVehicleModel);
                this.defeatedVehicles.Add(targetVehicleModel);
            }
            else
            {
                this.vehicles[attackerVehicleModel]
                    .Parts
                    .ToList()
                    .ForEach(x => this.parts.Remove(x.Model));

                this.vehicles.Remove(attackerVehicleModel);

                this.defeatedVehicles.Add(attackerVehicleModel);
            }

            return string.Format(
                GlobalConstants.BattleSuccessMessage,
                attackerVehicleModel,
                targetVehicleModel,
                winnerVehicleModel);
        }

        public string Terminate(IList<string> arguments)
        {
            StringBuilder finalResult = new StringBuilder();

            finalResult.Append("Remaining Vehicles: ");

            if (this.vehicles.Count > 0)
            {
                finalResult
                    .AppendLine(string.Join(", ",
                        this.vehicles
                            .Values
                            .Select(v => v.Model)
                            .ToArray()));
            }
            else
            {
                finalResult.AppendLine("None");
            }

            finalResult.Append("Defeated Vehicles: ");

            if (this.defeatedVehicles.Count > 0)
            {
                finalResult
                    .AppendLine(string.Join(", ", this.defeatedVehicles));
            }
            else
            {
                finalResult
                    .AppendLine("None");
            }

            finalResult
                .Append("Currently Used Parts: ")
                .Append(this.parts.Count);

            return finalResult.ToString();
        }
    }
}