using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CosmosX.Core.Contracts;
using CosmosX.Entities.CommonContracts;
using CosmosX.Entities.Containers;
using CosmosX.Entities.Containers.Contracts;
using CosmosX.Entities.Modules.Absorbing.Contracts;
using CosmosX.Entities.Modules.Contracts;
using CosmosX.Entities.Modules.Energy;
using CosmosX.Entities.Modules.Energy.Contracts;
using CosmosX.Entities.Reactors;
using CosmosX.Entities.Reactors.Contracts;
using CosmosX.Entities.Reactors.ReactorFactory;
using CosmosX.Entities.Reactors.ReactorFactory.Contracts;
using CosmosX.Utils;

namespace CosmosX.Core
{
    public class ReactorManager : IManager
    {
        private int currentId;
        private readonly IDictionary<int, IIdentifiable> identifiableObjects;
        private readonly IDictionary<int, IReactor> reactors;
        private readonly IDictionary<int, IModule> modules;
        private readonly IReactorFactory reactorFactory;

        public ReactorManager()
        {
            this.currentId = Constants.StartingId;
            this.identifiableObjects = new Dictionary<int, IIdentifiable>();
            this.reactors = new Dictionary<int, IReactor>();
            this.modules = new Dictionary<int, IModule>();
            this.reactorFactory = new ReactorFactory();
        }

        public string ReactorCommand(IList<string> arguments)
        {
            string reactorType = arguments[0];
            int additionalParameter = int.Parse(arguments[1]);
            int moduleCapacity = int.Parse(arguments[2]);

            IContainer container = new ModuleContainer(moduleCapacity);

            IReactor reactor = this.reactorFactory.CreateReactor(
                reactorType,
                this.currentId,
                container,
                additionalParameter);

            this.currentId++;

            this.reactors.Add(reactor.Id, reactor);
            this.identifiableObjects.Add(reactor.Id, reactor);
            //Created {type} Reactor – {id}
            string result = string.Format(Constants.ReactorCreateMessage, reactorType, reactor.Id);
            return result;
        }

        public string ModuleCommand(IList<string> arguments)
        {
            int reactorId = int.Parse(arguments[0]);
            string moduleType = arguments[1];
            int additionalParameter = int.Parse(arguments[2]);

            switch (moduleType)
            {
                case "CryogenRod":
                    IEnergyModule cryogenRod = new CryogenRod(this.currentId, additionalParameter);
                    this.reactors[reactorId].AddEnergyModule(cryogenRod);
                    this.identifiableObjects.Add(cryogenRod.Id, cryogenRod);
                    this.modules.Add(cryogenRod.Id, cryogenRod);
                    break;
                case "HeatProcessor":
                    IAbsorbingModule heatProcessor = new HeatProcessor(this.currentId, additionalParameter);
                    this.reactors[reactorId].AddAbsorbingModule(heatProcessor);
                    this.identifiableObjects.Add(heatProcessor.Id, heatProcessor);
                    this.modules.Add(heatProcessor.Id, heatProcessor);
                    break;
                case "CooldownSystem":
                    break;
            }


            string result = string.Format(Constants.ModuleCreateMessage, moduleType, this.currentId++, reactorId);
            return result;
        }

        public string ReportCommand(IList<string> arguments)
        {
            int id = int.Parse(arguments[0]);

            //string result = (string)this.tankManager
            //    .GetType()
            //    .GetMethods()
            //    .FirstOrDefault(m => m.Name.Contains(command))
            //    .Invoke(this.tankManager, new object[] { inputParameters });

            var sb = new StringBuilder();

            var check = this.reactors.Values.FirstOrDefault(x => x.Id == id);

            if (check != null)
            {
                sb.AppendLine($"{check.GetType().Name} - {id}");
                sb.AppendLine($"Energy Output: {check.TotalEnergyOutput}");
                sb.AppendLine($"Heat Absorbing: {check.TotalHeatAbsorbing}");
                sb.AppendLine($"Modules: {check.ModuleCount}");

                return sb.ToString().Trim();
            }

            var module = this.modules.Values.FirstOrDefault(x => x.Id == id);
           // var module1 = this.modules.Keys.FirstOrDefault(x => x.Id == id);

            sb.AppendLine($"{module.GetType().Name} Module – {id}");
            sb.AppendLine($"{module.Id}: {module.GetType().BaseType.Name}");

            return sb.ToString();

        }

        public string ExitCommand(IList<string> arguments)
        {
            long cryoReactorCount = this.reactors
                .Values
                .Count(r => r.GetType().Name == nameof(CryoReactor));

            long heatReactorCount = this.reactors
                .Values
                .Count(r => r.GetType().Name == nameof(HeatReactor));

            long energyModulesCount = this.modules
                .Values
                .Count(m => m is IEnergyModule);

            long absorbingModulesCount = this.modules
                .Values
                .Count(m => m is IAbsorbingModule);

            long totalEnergyOutput = this.reactors
                .Values
                .Sum(r => r.TotalEnergyOutput);

            long totalHeatAbsorbing = this.reactors
                .Values
                .Sum(r => r.TotalHeatAbsorbing);

            string result = $"Cryo Reactors: {cryoReactorCount}\n" +
                            $"Heat Reactors: {heatReactorCount}\n" +
                            $"Energy Modules: {energyModulesCount}\n" +
                            $"Absorbing Modules: {absorbingModulesCount}\n" +
                            $"Total Energy Output: {totalEnergyOutput}\n" +
                            $"Total Heat Absorbing: {totalHeatAbsorbing}\n";

            return result;
        }
    }
}