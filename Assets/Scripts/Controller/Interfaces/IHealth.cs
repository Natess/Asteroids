﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    internal interface IHealth
    {
        float Health { get; }

        void Damage();
    }
}
