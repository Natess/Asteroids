using UnityEngine;

namespace Asteroids
{
    public class UFOShootingShip : IShooting
    {
        public float Force { get; protected set; }

        private Sprite _sprite;
        private GameObjectBuilder _builder;

        public UFOShootingShip(float force, Sprite sprite, GameObjectBuilder objectBuilder)
        {
            Force = force;
            _sprite = sprite;
            _builder = objectBuilder;
        }

        /// Демонстрация паттерна строителя
        public void Fire(Transform barrel)
        {
            var bullet = _builder
                .Visual
                .Name("UfoBullet")
                .Sprite(_sprite)
                .Physics
                .BoxCollider2D()
                .Position(barrel.position)
                .RigidBody2D(1)
                .AddForce(barrel.up * Force, ForceMode2D.Impulse);
        }
    }
}
