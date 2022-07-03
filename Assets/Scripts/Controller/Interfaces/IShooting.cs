using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    internal interface IShooting
    {
        float Force { get; }
        void Fire(Transform barrel);
    }
}
