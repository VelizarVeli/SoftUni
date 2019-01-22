using System.Collections.Generic;

namespace DungeonsAndCodeWizards.Items
{
    public class Bag:Item
    {
        private int capacity;
        private List<Item> items;

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


        private List<Item> Items
        {
            get { return items; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

    }
}
