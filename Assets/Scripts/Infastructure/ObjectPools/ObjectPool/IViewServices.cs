using UnityEngine;

namespace Asteroids
{
    internal interface IViewServices
    {
        T Instantiate<T>(GameObject prefabs);
        GameObject Instantiate(GameObject prefabs);

        void Destroy(GameObject gameObject);
    }
}
