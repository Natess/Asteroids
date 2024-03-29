using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private GameObject _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;

        private PlayerMovement _playerMovement;
        private PlayerWeaponProxy _playerWeapon;
        private PlayerHealth _playerHealth;
        private IViewServices _playerViewServices;

        private void Start()
        {
            _playerViewServices = ServiceLocator.Resolve<IViewServices>();//ViewServicesFactory.Instance();

            var move = new MovePhysics(gameObject.GetComponent<Rigidbody2D>(), _speed);
            var rotation = new RotationShip(transform);
            _playerMovement = new PlayerMovement(move, rotation);

            var shooting = new ShootingShip(_bullet, _force, _playerViewServices);
            _playerWeapon = new PlayerWeaponProxy(shooting, new UnlockWeapon(false));

            var health = new HealthShip(gameObject, _hp);
            _playerHealth = new PlayerHealth(health);
        }

        internal void UnlockWeapon()
        {
            _playerWeapon.SwitchWeapon();
        }

        public void Fire() =>
            _playerWeapon.Fire(_barrel);

        public void Move(float horizontal, float vertical) =>
            _playerMovement.Move(horizontal, vertical, Time.deltaTime);

        internal void Rotation(Vector3 direction) =>
            _playerMovement.Rotation(direction);

        internal void AddAcceleration() =>
            _playerMovement.AddAcceleration();

        internal void RemoveAcceleration() =>
            _playerMovement.RemoveAcceleration();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("PlayerBullet"))
                _playerHealth.Damage();
        }

        private void OnDestroy()
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}