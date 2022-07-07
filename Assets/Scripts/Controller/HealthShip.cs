using System;
using UnityEngine;

namespace Asteroids
{
    internal class HealthShip : IHealth
    {
        private readonly GameObject _gameObject;
        public float Health { get; protected set; }

        public HealthShip(GameObject gameObject, float health)
        {
            _gameObject = gameObject;
            Health = health;
        }

        public void Damage()
        {
            Health--;
            if (Health <= 0)
            {
                UnityEngine.Object.Destroy(_gameObject);
            }
        }
    }
}
