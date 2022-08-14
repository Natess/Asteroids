using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    internal class FieldOfViewVisitor : IFieldOfViewVisitor
    {
        public void Visit(Enemy enemy)
        {
            Debug.Log("Enemy in field of view");
        }

        public void Visit(Asteroid asteroid)
        {
            Debug.Log("Asteroid in field of view");
        }

        public void Visit(UFO ufo)
        {
            Debug.Log("UFO in field of view");
        }
    }
}
