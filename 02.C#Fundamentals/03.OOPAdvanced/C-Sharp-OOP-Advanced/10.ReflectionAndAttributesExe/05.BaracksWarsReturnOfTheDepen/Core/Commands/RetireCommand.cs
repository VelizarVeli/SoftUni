namespace _03BarracksFactory.Core.Commands
{
    using Contracts;
    using System;

    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            try
            {
                this.Repository.RemoveUnit(unitType);
                string output = unitType + " retired!";
                return output;
            }
            catch (Exception e)
            {
                throw new ArgumentException("No such units in repository.", e);
            }
        }
    }
}