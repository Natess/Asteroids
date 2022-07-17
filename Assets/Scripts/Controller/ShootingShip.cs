using UnityEngine;

namespace Asteroids
{
    internal class ShootingShip : IShooting
    {
        protected readonly GameObject _bullet;
        public float Force {get; protected set;}

        protected IViewServices _viewServices;

        public ShootingShip(GameObject bullet, float force, IViewServices viewServices)
        {
            _bullet = bullet;
            Force = force;
            _viewServices = viewServices;
        }

        public virtual void Fire(Transform barrel)
        {
            var temAmmunition = _viewServices.Instantiate<Rigidbody2D>(_bullet);
            temAmmunition.transform.position = barrel.position;
            temAmmunition.AddForce(barrel.up * Force, ForceMode2D.Impulse);
        }
    }
}
