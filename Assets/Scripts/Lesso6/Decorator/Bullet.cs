using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids.Lesson6
{
    internal sealed class Bullet : IAmmunition
    {
        public Rigidbody BulletInstance { get; }
        public float TimeToDestroy { get; }
        public Bullet(Rigidbody bulletInstance, float timeToDestroy)
        {
            BulletInstance = bulletInstance;
            TimeToDestroy = timeToDestroy;
        }
    }
}
