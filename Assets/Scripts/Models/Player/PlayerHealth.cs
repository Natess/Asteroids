using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    internal class PlayerHealth : IHealth
    {
        private readonly IHealth _healthImplementation;
        public float Health => _healthImplementation.Health;

        public PlayerHealth(IHealth healthImplementation)
        {
            _healthImplementation = healthImplementation;
        }

        public void Damage()
        {
            _healthImplementation.Damage();
        }
    }
}
