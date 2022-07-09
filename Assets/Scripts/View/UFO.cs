using UnityEngine;

namespace Asteroids
{
    internal class UFO: Enemy
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        [SerializeField] private float _fireTimerPeriod = 1;
        [SerializeField] private float _ufoSpeed = 5;

        private UfoShootingController _shootinController;

        private void Awake()
        {
            var move = new MovePhysics(gameObject.GetComponent<Rigidbody2D>(), _ufoSpeed);
            _movement = new EnemyMovementToCentreWithOffset(move, transform);

            _movement.StartMove();
            Object.Destroy(gameObject, _lifeTime);
        }

        internal void DependencyInjectViewServices(IViewServices viewServices)
        {
            var shooting = new ShootingShip(_bullet, _force, viewServices);
            _shootinController = new UfoShootingController(shooting, _barrel, _fireTimerPeriod);
        }

        private void Update()
        {
            _shootinController.Update();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("PlayerBullet"))
                _health.Damage();
        }
    }
}
