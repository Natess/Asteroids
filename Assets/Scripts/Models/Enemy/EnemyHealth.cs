using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    internal class EnemyHealth : IEnemyHealth
    {
        public Health HP { get; set; }

        private GameObject _gameObject;

        public EnemyHealth(Health hp, GameObject ganeObject)
        {
            HP = hp;
            _gameObject = ganeObject;
        }

        public void Damage()
        {
            HP.GetDamage(1);
            if (HP.Current <= 0)
            {
                UnityEngine.Object.Destroy(_gameObject);
            }
        }
    }
}
