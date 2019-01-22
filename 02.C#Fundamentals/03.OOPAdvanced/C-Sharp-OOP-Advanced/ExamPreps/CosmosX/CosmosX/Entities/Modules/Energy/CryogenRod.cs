namespace CosmosX.Entities.Modules.Energy
{
    public class CryogenRod : BaseEnergyModule
    {
        public CryogenRod(int id, int energyOutput)
            : base(id, energyOutput)
        {
            this.EnergyOutput = energyOutput;
        }

        public override int EnergyOutput { get; protected set; }
    }
}