using UnityEngine;

namespace Asteroids
{
    internal interface IShooting
    {
        float Force { get; }
        void Fire(Transform barrel);
    }
}
