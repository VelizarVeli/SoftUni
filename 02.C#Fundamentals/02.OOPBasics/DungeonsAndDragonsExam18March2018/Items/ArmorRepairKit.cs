using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Characters;

namespace DungeonsAndCodeWizards.Items
{
    public class ArmorRepairKit : Item
    {
        private int armor;
        public ArmorRepairKit(int armor):base(armor)
        {
            this.Weight = 10;
        }

        public ArmorRepairKit()
        {
            
        }
    }
}
