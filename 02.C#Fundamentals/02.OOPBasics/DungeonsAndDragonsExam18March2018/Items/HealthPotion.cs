using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Characters;

namespace DungeonsAndCodeWizards.Items
{
    public class HealthPotion : Item
    {
        private int health;

        public HealthPotion(int health)
            :base(health + 20)
        {
            this.Weight = 5;
        }

        public HealthPotion()
        {
            
        }
    }
}
