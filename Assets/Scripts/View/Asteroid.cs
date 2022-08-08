
using UnityEngine;

namespace Asteroids
{
    public class Asteroid : Enemy
    {
        [SerializeField] private float _asteroidSpeed = 5;

        private void Awake()
        {
            var move = new MovePhysics(gameObject.GetComponent<Rigidbody2D>(), _asteroidSpeed);
            _movement = new EnemyMovementToCentreWithOffset(move, transform);

            _movement.StartMove();
            Object.Destroy(gameObject, _lifeTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("PlayerBullet"))
                _health.Damage();
        }
    }
}