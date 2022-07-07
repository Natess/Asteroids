using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    internal class MovePhysics : IMove
    {
        private readonly Rigidbody2D _body;
        private Vector3 _move;

        public float Speed { get; protected set; }

        public MovePhysics(Rigidbody2D body, float speed)
        {
            _body = body;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal, vertical, 0.0f);
            _body.AddForce(_move.normalized * speed);
        }
    }
}
