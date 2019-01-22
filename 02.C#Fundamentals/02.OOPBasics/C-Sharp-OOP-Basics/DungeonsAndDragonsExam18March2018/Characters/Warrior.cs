using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards.Characters
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, double health, double armor, double abilityPoints, Bag bag)
            : base(name, health, armor, abilityPoints, bag)
        {

        }
    }
}
