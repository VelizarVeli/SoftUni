using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SIS.Services.Contracts;

namespace SIS.Services
{
    public class ServiceCollection : IServiceCollection
    {
	private readonly IDictionary<Type, Type> services;

	public ServiceCollection()
	{
	    services = new Dictionary<Type, Type>();
	}

	private Type this[Type key]
	    => services.ContainsKey(key) ? services[key] : null;

	public T GetDbContext<T>()
	{
	    Type dbContextType = typeof(T);
	    if (!services.ContainsKey(dbContextType))
	    {
		throw new ArgumentNullException($"No database context of type {dbContextType.Name} has been registered.");
	    }
	    var dbContext = Activator.CreateInstance(dbContextType);
	    return (T)dbContext;
	}

	public T GetService<T>() => (T)GetService(typeof(T));

	public object GetService(Type type)
	{
	    if (type == null) return null;
	    Type serviceType = this[type] ?? type;
	    if (serviceType == typeof(IServiceCollection)) return this;
	    if (serviceType.IsAbstract || serviceType.IsInterface)
	    {
		throw new InvalidOperationException($"Service {serviceType.FullName} cannot be instantiated.");
	    }
	    ConstructorInfo serviceConstructor = serviceType.GetConstructors()
		.OrderBy(c => c.GetParameters().Length).First();
	    ParameterInfo[] constructorParameters = serviceConstructor.GetParameters();
	    object[] serviceDependencies = new object[constructorParameters.Length];
	    for (int i = 0; i < serviceDependencies.Length; i++)
	    {
		var dependencyType = constructorParameters[i].ParameterType;
		serviceDependencies[i] = GetService(dependencyType);
	    }
	    object service = serviceConstructor.Invoke(serviceDependencies);
	    return service;
	}

	public void RegisterDbContext<TDbContext>()
	{
	    services[typeof(TDbContext)] = typeof(TDbContext);
	}

	public void RegisterService<TInterface, TImplementation>()
	{
	    services[typeof(TInterface)] = typeof(TImplementation);
	}
    }
}
