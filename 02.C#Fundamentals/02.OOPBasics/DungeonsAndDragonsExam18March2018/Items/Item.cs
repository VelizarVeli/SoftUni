using System;
using DungeonsAndCodeWizards.Characters;

namespace DungeonsAndCodeWizards
{
    public abstract class Item
    {
        public int Weight { get; protected set; }

        public Item()
        {
            
        }

        protected Item(int weight)
        {
            Weight = weight;
        }
        public void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
