using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(List<string> args)
        {
            var type = args[0];
            var id = args[1];
            var energyOutput = double.Parse(args[2]);

            switch (type)
            {
                case "Solar":
                    return new ArmorRepairKit();
                //case "Pressure":
                //    return new Bagpack();
                //case "Pressure":
                //    return new Bag();
                //case "Pressure":
                //    return new Bag();
                //case "Pressure":
                //    return new Bag();
                //case "Pressure":
                //    return new Bag();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
