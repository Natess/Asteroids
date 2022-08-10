using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    internal abstract class BaseUi : MonoBehaviour
    {
        public abstract void Execute();

        public abstract void Cancel();

    }
}
