public class EnergyRepository : IEnergyRepository
{
    public double EnergyStored { get; }
    public bool TakeEnergy(double energyNeeded)
    {
        throw new System.NotImplementedException();
    }

    public void StoreEnergy(double energy)
    {
        throw new System.NotImplementedException();
    }
}