using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _serviceContainer =
            new Dictionary<Type, object>();

        public static void SetService<T>(T value)
            where T : class
        {
            var typeValue = typeof(T);
            if(!_serviceContainer.ContainsKey(typeValue))
            {
                _serviceContainer[typeValue] = value;
            }
        }

        public static T Resolve<T>()
        {
            var typeValue = typeof(T);
            if(_serviceContainer.ContainsKey(typeValue))
            {
                return (T)_serviceContainer[typeValue];
            }

            return default;
        }
    }
}
