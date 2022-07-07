using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public sealed class Health
    {
        public float Max { get; }
        public float Current { get; private set; }

        public Health(float max, float current)
        {
            Max = max;
            Current = current;
        }
        public void ChangeCurrentHealth(float hp)
        {
            Current = hp;
        }
        public void GetDamage(float damage)
        {
            Current -= damage;
        }
    }
}
