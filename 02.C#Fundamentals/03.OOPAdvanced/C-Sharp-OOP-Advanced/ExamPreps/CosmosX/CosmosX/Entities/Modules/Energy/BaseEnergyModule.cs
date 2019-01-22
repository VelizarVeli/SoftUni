using CosmosX.Entities.Modules.Energy.Contracts;

namespace CosmosX.Entities.Modules.Energy
{
    public abstract class BaseEnergyModule : BaseModule, IEnergyModule
    {
        protected BaseEnergyModule(int id, int energyOutput)
            : base(id)
        {
        }

        public abstract int EnergyOutput { get; protected set; }

        public override string ToString()
        {
            return base.ToString() + $"Energy Output: {this.EnergyOutput}";
        }
    }
}