using UnityEngine;

namespace Asteroids.Lesson6
{
    public interface IAmmunition
    {
        Rigidbody BulletInstance { get; }
        float TimeToDestroy { get; }

    }
}