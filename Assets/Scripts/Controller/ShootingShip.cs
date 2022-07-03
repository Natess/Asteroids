using UnityEngine;

namespace Asteroids
{
    internal class ShootingShip : IShooting
    {
        private readonly GameObject _bullet;
        public float Force {get; protected set;}

        public ShootingShip(GameObject bullet, float force)
        {
            _bullet = bullet;
            Force = force;
        }

        public void Fire(Transform barrel)
        {
            var temAmmunition = Object.Instantiate(_bullet, barrel.position, barrel.rotation);
            temAmmunition.GetComponent<Rigidbody2D>().AddForce(barrel.up * Force);
            Object.Destroy(temAmmunition, 10);
        }
    }
}
