using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    internal interface IAbility
    {
        string Name { get; }
        int Damage { get; }
        Target Target { get; }
        DamageType DamageType { get; }
    }

}
