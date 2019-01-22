using CosmosX.Entities.Modules.Absorbing;

namespace CosmosX.Entities.Modules.Energy
{
    public class CooldownSystem : BaseAbsorbingModule
    {
        public CooldownSystem(int id, int heatAbsorbing) : base(id, heatAbsorbing)
        {
        }
    }
}
