﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    internal class PlayerMovement : IMove, IRotation
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplementation;

        public float Speed => _moveImplementation.Speed;

        public PlayerMovement(IMove moveImplementation, IRotation rotationImplementation)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime);
        }

        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }

        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }
    }
}
