using System;

namespace SIS.Services.Contracts
{
    public interface IServiceCollection
    {
	T GetDbContext<T>();
	T GetService<T>();
	object GetService(Type type);
	void RegisterDbContext<TDbContext>();
	void RegisterService<TInterface, TImplementation>();
    }
}
