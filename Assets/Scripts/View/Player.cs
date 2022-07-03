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

        private Camera _camera;
        private PlayerMovement _playerMovement;
        private PlayerWeapon _playerWeapon;
        private PlayerHealth _playerHealth;

        private void Start()
        {
            _camera = Camera.main;
            var move = new MovePhysics(gameObject.GetComponent<Rigidbody2D>(), _speed);
            var rotation = new RotationShip(transform);
            _playerMovement = new PlayerMovement(move, rotation);

            var shooting = new ShootingShip(_bullet, _force);
            _playerWeapon = new PlayerWeapon(shooting);

            var health = new HealthShip(gameObject, _hp);
            _playerHealth = new PlayerHealth(health);
        }

        private void FixedUpdate()
        {
            Move();
            Fire();
        }

        private void Fire()
        {
            if (Input.GetButton("Fire1"))
            {
                _playerWeapon.Fire(_barrel);
            }
        }

        private void Move()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _playerMovement.Rotation(direction);

            _playerMovement.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _playerMovement.AddAcceleration();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _playerMovement.RemoveAcceleration();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _playerHealth.Damage();
        }
    }
}