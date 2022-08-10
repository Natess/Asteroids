using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    internal interface IAbilityEnemy
    {
        IAbility this[int index] { get; }

        string this[Target index] { get; }

        int MaxDamage { get; }

        IEnumerable<IAbility> GetAbility();
        IEnumerator GetEnumerator();
        IEnumerable<IAbility> GetAbility(DamageType index);
    }
}
