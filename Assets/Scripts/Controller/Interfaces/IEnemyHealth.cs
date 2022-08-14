using System;

namespace Asteroids
{
    public interface IEnemyHealth
    {
        public Health HP { get; set; }

        public event Action OnDead;
        public void Damage();

    }
}