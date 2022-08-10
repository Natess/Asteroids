using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    [Flags]
    internal enum Target
    {
        None = 0,
        Unit = 1,
        Autocast = 2,
        Passive = 4,
    }
    internal enum DamageType
    {
        None = 0,
        Magical = 1,
        Pure = 2,
    }
}
