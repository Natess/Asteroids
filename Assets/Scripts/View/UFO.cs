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

        private IShooting _ufoWeapon;

        private void Awake()
        {
            var move = new MovePhysics(gameObject.GetComponent<Rigidbody2D>(), _ufoSpeed);
            _movement = new RandomEnemyMovement(move, transform);

            StartMove();
            Object.Destroy(gameObject, 20);
        }

        internal void DependencyInjectViewServices(IViewServices viewServices)
        {
            var shooting = new ShootingShip(_bullet, _force, viewServices);
            _ufoWeapon = new EnemyWeapon(shooting);
        }

        public void StartMove()
        {
            _movement.StartMove();
        }

        float _fireTimer = 0;
        private void Update()
        {
            _fireTimer -= Time.deltaTime;
            if (_fireTimer < 0)
            {
                _ufoWeapon.Fire(_barrel);
                _fireTimer = _fireTimerPeriod;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("PlayerBullet"))
                _health.Damage();
        }
    }
}
