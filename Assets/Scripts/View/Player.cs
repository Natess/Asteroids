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

        internal PlayerMovement PlayerMovement;
        internal PlayerWeaponProxy PlayerWeapon;
        internal PlayerHealth PlayerHealth;
        private IViewServices _playerViewServices;

        private void Awake()
        {
            _playerViewServices = ServiceLocator.Resolve<IViewServices>();//ViewServicesFactory.Instance();

            var move = new MovePhysics(gameObject.GetComponent<Rigidbody2D>(), _speed);
            var rotation = new RotationShip(transform);
            PlayerMovement = new PlayerMovement(move, rotation);

            var shooting = new ShootingShip(_bullet, _force, _playerViewServices);
            PlayerWeapon = new PlayerWeaponProxy(shooting, new UnlockWeapon(false));

            var health = new HealthShip(gameObject, _hp);
            PlayerHealth = new PlayerHealth(health);
        }

        internal void UnlockWeapon()
        {
            PlayerWeapon.SwitchWeapon();
        }

        public void Fire() =>
            PlayerWeapon.Fire(_barrel);

        public void Move(float horizontal, float vertical) =>
            PlayerMovement.Move(horizontal, vertical, Time.deltaTime);

        internal void Rotation(Vector3 direction) =>
            PlayerMovement.Rotation(direction);

        internal void AddAcceleration() =>
            PlayerMovement.AddAcceleration();

        internal void RemoveAcceleration() =>
            PlayerMovement.RemoveAcceleration();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("PlayerBullet"))
                PlayerHealth.Damage();
        }

        private void OnDestroy()
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}