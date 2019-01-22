using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Characters;

namespace DungeonsAndCodeWizards.Items
{
    public class PoisonPotion:Item
    {
        private int health;

        public PoisonPotion(int health)
            : base(health - 20)
        {
            this.Weight = 5;
        }

        public PoisonPotion()
        {

        }
    }
}
