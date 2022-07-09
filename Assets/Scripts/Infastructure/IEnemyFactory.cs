using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    public interface IEnemyFactory
    {
        Enemy Create(EnemyTypes enemyType, Health hp);
        Enemy Create(EnemyTypes enemyType, Health hp, Vector3 position);
    }
}
