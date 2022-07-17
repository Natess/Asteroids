using UnityEngine;

namespace Asteroids
{
    internal interface IViewServices
    {
        T Instantiate<T>(GameObject prefabs);

        void Destroy(GameObject gameObject);
    }
}
