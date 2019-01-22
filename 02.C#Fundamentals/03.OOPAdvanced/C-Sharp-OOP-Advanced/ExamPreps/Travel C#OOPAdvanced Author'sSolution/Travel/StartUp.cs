namespace Travel
{
	using System;
	using System.IO;
	using System.Linq;
	using Core;
	using Core.Contracts;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;
	using Entities.Airplanes;
	using Entities.Contracts;
	using Entities.Items;
	using Entities.Items.Contracts;

	public static class StartUp
	{
		public static void Main(string[] args)
		{
			IReader reader = new ConsoleReader();
			IWriter writer = new ConsoleWriter();

			IAirport airport = new Airport();
			IAirportController airportController = new AirportController(airport);
			IFlightController flightController = new FlightController(airport);

			IEngine engine = new Engine(reader, writer, airportController, flightController);

			engine.Run();
		}
	}
}