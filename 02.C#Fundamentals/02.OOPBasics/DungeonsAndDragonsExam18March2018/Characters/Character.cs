using System;
using DungeonsAndCodeWizards.Items;

namespace DungeonsAndCodeWizards.Characters
{
    public class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private const string faction = "CSharp";
        private bool isAlive;

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = true; }
        }

        public string Name
        {
            get { return name; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public double BaseHealth
        {
            get { return baseHealth; }
            set { baseHealth = value; }
        }

        protected double Health
        {
            get { return health; }
            set
            {
                if (value > BaseHealth)
                {
                    value = BaseHealth;
                }

                if (value < 0)
                {
                    value = 0;
                }
                health = value;
            }
        }

        public double BaseArmor
        {
            get { return baseArmor; }
            private set { baseArmor = value; }
        }

        public double Armor
        {
            get { return armor; }
            protected set
            {
                if (value > baseArmor)
                {
                    value = BaseArmor;
                }

                if (value < 0)
                {
                    value = 0;
                }
                armor = value;
            }
        }

        public double AbilityPoints
        {
            protected get { return abilityPoints; }
            set
            {

                abilityPoints = value;
            }
        }

        public Bag bag { get; set; }

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            Health = health;
            Armor = armor;
            AbilityPoints = abilityPoints;
        }
    }
}
