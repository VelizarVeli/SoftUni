namespace _03BarracksFactory.Models.Units
{
    class Horseman : Unit
    {
        private const int DefaultHealth = 20;
        private const int DefaultDamage = 20;

        public Horseman()
            : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}