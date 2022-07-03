using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    internal class PlayerWeapon : IShooting
    {
        private readonly IShooting _shootingImplementation;
        public float Force => _shootingImplementation.Force;
        
        public PlayerWeapon(IShooting shootingImplementation)
        {
            _shootingImplementation = shootingImplementation;
        }

        public void Fire(Transform barrel)
        {
            _shootingImplementation.Fire(barrel);
        }
    }
}
