namespace SIS.MVC.Framework.Services
{
    using Common;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ServiceCollection : IServiceCollection
    {
        private readonly IDictionary<Type, Type> dependencyContainer;

        public ServiceCollection()
        {
            this.dependencyContainer = new Dictionary<Type, Type>();
        }

        public void AddService<TSource, TDestination>()
        {
            this.dependencyContainer[typeof(TSource)] = typeof(TDestination);
        }

        public T CreateInstance<T>()
        {
            return (T)this.CreateInstance(typeof(T));
        }

        public object CreateInstance(Type type)
        {
            if (this.dependencyContainer.ContainsKey(type))
            {
                type = this.dependencyContainer[type];
            }

            if (type.IsInterface || type.IsAbstract)
            {
                throw new Exception(string.Format(Constants.TypeNonInstanceable, type));
            }

            var constructor = type.GetConstructors().OrderBy(c => c.GetParameters().Length).First();
            var constrParams = constructor.GetParameters();
            var constrParamsList = new List<object>();
            foreach (var paramInfo in constrParams)
            {
                constrParamsList.Add(this.CreateInstance(paramInfo.ParameterType));
            }

            return constructor.Invoke(constrParamsList.ToArray());
        }
    }
}