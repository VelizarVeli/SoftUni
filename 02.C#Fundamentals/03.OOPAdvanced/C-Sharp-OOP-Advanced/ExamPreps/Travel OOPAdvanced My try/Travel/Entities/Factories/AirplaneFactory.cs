using System;
using System.Linq;
using System.Reflection;

namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;

	public class AirplaneFactory : IAirplaneFactory
	{
	    public IAirplane CreateAirplane(string type)
	    {
	        var airplaneTypes = Assembly.GetCallingAssembly().GetTypes()
	            .Where(t => typeof(IAirplane).IsAssignableFrom(t) && !t.IsAbstract)
	            .ToArray();

	        var airplanetType = airplaneTypes.FirstOrDefault(t => t.Name == type);

	        var airplane = (IAirplane)Activator.CreateInstance(airplanetType);

	        return airplane;
        }
	}
}