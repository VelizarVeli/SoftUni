namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
		    var instrumentTypes = Assembly.GetCallingAssembly().GetTypes()
		        .Where(t => typeof(IInstrument).IsAssignableFrom(t) && !t.IsAbstract)
		        .ToArray();

		    var instrumentType = instrumentTypes.FirstOrDefault(t => t.Name == type);

		    var instrument = (IInstrument)Activator.CreateInstance(instrumentType);

		    return instrument;
        }
	}
}