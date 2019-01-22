using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SIS.Framework.Services.Contracts;

namespace SIS.Framework.Services
{
    public class DependencyContainer : IDependencyContainer
    {
        private readonly IDictionary<Type, Type> dependencyDictionary;

        public DependencyContainer(IDictionary<Type, Type> dependencyDictionary)
        {
            this.dependencyDictionary = dependencyDictionary;
        }

        private Type this[Type key] => 
            this.dependencyDictionary.ContainsKey(key) 
                ? this.dependencyDictionary[key] 
                : null;

        public void RegisterDependency<TSource, TDestination>()
        {
            this.dependencyDictionary[typeof(TSource)] = typeof(TDestination);
        }

        public T CreateInstance<T>() =>
            (T) CreateInstance(typeof(T));

        public object CreateInstance(Type type)
        {
            Type instanceType = this[type] ?? type; 

            if (instanceType.IsInterface || instanceType.IsAbstract)
            {
                throw new InvalidOperationException(
                    $"Type {instanceType.FullName} cannot be instantiated.");
            }

            ConstructorInfo constructor = instanceType
                .GetConstructors()
                .OrderBy(c => c.GetParameters().Length)
                .First();

            ParameterInfo[] constructorParameters = constructor.GetParameters();

            object[] constructorParameterObjects = new object[constructorParameters.Length];

            for (int i = 0; i < constructorParameters.Length; i++)
            {
                constructorParameterObjects[i] = this.CreateInstance(constructorParameters[i].ParameterType);
            }

            return constructor.Invoke(constructorParameterObjects);
        }
    }
}
