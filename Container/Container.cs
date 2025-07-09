using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private Dictionary<Type, Type> _interfaceToImplementationMap = [];

        public void Bind(Type interfaceType, Type implementationType)
        {
            ValidateBindArguments(interfaceType, implementationType);

            _interfaceToImplementationMap[interfaceType] = implementationType;
        }

        public T Get<T>()
        {
            var interfaceType = typeof(T);

            if (!_interfaceToImplementationMap.TryGetValue(interfaceType, out Type value))
            {
                throw new InvalidOperationException();
            }

            return (T)Activator.CreateInstance(value);
        }

        private void ValidateBindArguments(Type interfaceType, Type implementationType)
        {
            ArgumentNullException.ThrowIfNull(interfaceType);

            ArgumentNullException.ThrowIfNull(implementationType);

            if (!implementationType.IsAssignableTo(interfaceType))
            {
                throw new ArgumentException("implementationType is not assignable to interfaceType");
            }

            if (_interfaceToImplementationMap.ContainsKey(interfaceType))
            {
                throw new ArgumentException("interfaceType already bound to an implementation");
            }
        }
    }
}
