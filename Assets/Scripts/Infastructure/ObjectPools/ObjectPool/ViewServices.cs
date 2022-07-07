using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    internal class ViewServices : IViewServices
    {
        private readonly Dictionary<string, ObjectPool> _viewCache
            = new Dictionary<string, ObjectPool>(10);

        public T Instantiate<T>(GameObject prefab)
        {
            if(!_viewCache.TryGetValue(prefab.name, out ObjectPool viewPool))
            {
                viewPool = new ObjectPool(prefab);
                _viewCache[prefab.name] = viewPool;
            }
            if (viewPool.Pop().TryGetComponent(out T component))
                return component;

            throw new InvalidOperationException($"{typeof(T)} not found");
        }

        public void Destroy(GameObject gameObject)
        {
            _viewCache[gameObject.name].Push(gameObject);
        }

        public GameObject Instantiate(GameObject prefab)
        {
            if (!_viewCache.TryGetValue(prefab.name, out ObjectPool viewPool))
            {
                viewPool = new ObjectPool(prefab);
                _viewCache[prefab.name] = viewPool;
            }
            return viewPool.Pop();
        }
    }
}
