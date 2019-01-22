namespace SIS.Framework.Services
{
    using Common;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DependencyContainer : IDependencyContainer
    {
        private readonly IDictionary<Type, Type> dependencyDictionary;

        public DependencyContainer()
        {
            this.dependencyDictionary = new Dictionary<Type, Type>();
        }

        private Type this[Type key] =>
            this.dependencyDictionary.ContainsKey(key) ? this.dependencyDictionary[key] : null;

        public void RegisterDependency<TSource, TDestination>()
        {
            this.dependencyDictionary[typeof(TSource)] = typeof(TDestination);
        }

        public T CreateInstance<T>() => (T)this.CreateInstance(typeof(T));

        public object CreateInstance(Type type)
        {
            var instanceType = this[type] ?? type;
            if (instanceType.IsInterface || instanceType.IsAbstract)
            {
                throw new InvalidOperationException(string.Format(Messages.TypeCannotBeInstantiated, instanceType.FullName));
            }

            var constr = instanceType.GetConstructors().OrderByDescending(c => c.GetParameters().Length).First();
            var constrParams = constr.GetParameters();
            var constrParamsList = new object[constrParams.Length];
            for (int i = 0; i < constrParams.Length; i++)
            {
                constrParamsList[i] = this.CreateInstance(constrParams[i].ParameterType);
            }

            return constr.Invoke(constrParamsList);
        }
    }
}