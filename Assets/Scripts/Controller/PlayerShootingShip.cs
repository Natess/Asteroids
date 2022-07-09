using UnityEngine;

namespace Asteroids
{
    internal class PlayerShootingShip : ShootingShip
    {
        public PlayerShootingShip(GameObject bullet, float force, IViewServices viewServices): base(bullet, force, viewServices)
        {
        }

        public override void Fire(Transform barrel)
        {
            var temAmmunition = _viewServices.Instantiate<Rigidbody2D>(_bullet);
            temAmmunition.transform.position = barrel.position;
            temAmmunition.AddForce(barrel.up * Force, ForceMode2D.Impulse);
        }
    }
}
