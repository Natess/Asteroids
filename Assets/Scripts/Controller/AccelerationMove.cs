using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    internal class AccelerationMove : MoveTransform
    {
        private readonly float _accelaration;

        public AccelerationMove(Transform transform, float speed, float accelaration) : base(transform, speed)
        {
            _accelaration = accelaration;
        }

        public void AddAcceleration()
        {
            Speed += _accelaration;
        }
        public void RemoveAcceleration()
        {
            Speed -= _accelaration;
        }
    }
}
