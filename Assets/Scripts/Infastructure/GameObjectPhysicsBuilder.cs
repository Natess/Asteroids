using System;
using UnityEngine;

namespace Asteroids
{
    public class GameObjectPhysicsBuilder: GameObjectBuilder
    {
        public GameObjectPhysicsBuilder(GameObject gameObject): base(gameObject)
        {
        }

        public GameObjectPhysicsBuilder BoxCollider2D()
        {
            GetOrAddComponent<BoxCollider2D>();
            return this;
        }
        public GameObjectPhysicsBuilder RigidBody2D(float mass)
        {
            var component = GetOrAddComponent<Rigidbody2D>();
            component.mass = mass;
            return this;
        }

        private T GetOrAddComponent<T>()
            where T : Component
        {
            var result = _gameObject.GetComponent<T>();
            if(!result)
            {
                result = _gameObject.AddComponent<T>();
            }
            return result;
        }

        public GameObjectPhysicsBuilder AddForce(Vector3 vector3, ForceMode2D forceMode)
        {
            var component = GetOrAddComponent<Rigidbody2D>();
            component.AddForce(vector3, forceMode);
            return this;
        }

        internal GameObjectPhysicsBuilder Position(Vector3 position)
        {
            _gameObject.transform.position = position;
            return this;
        }
    }
}