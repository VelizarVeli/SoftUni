using TheTankGame.Entities.Parts.Contracts;

namespace TheTankGame.Entities.Parts
{
    public class ShellPart : BasePart, IDefenseModifyingPart
    {
        public ShellPart(string model, double weight, decimal price, int defenseModifier)
            : base(model, weight, price)
        {
            this.DefenseModifier = defenseModifier;
        }

        public int DefenseModifier { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"+{this.DefenseModifier} Defense";
        }
    }
}