using UnityEngine;

namespace Asteroids
{
    internal class ShootingShip : IShooting
    {
        private readonly GameObject _bullet;
        public float Force {get; protected set;}

        private IViewServices _viewServices;

        public ShootingShip(GameObject bullet, float force, IViewServices viewServices)
        {
            _bullet = bullet;
            Force = force;
            _viewServices = viewServices;
        }

        public void Fire(Transform barrel)
        {
            var temAmmunition = _viewServices.Instantiate(_bullet);
            temAmmunition.transform.position = barrel.position;
            temAmmunition.GetComponent<Rigidbody2D>().AddForce(barrel.up * Force, ForceMode2D.Impulse);

            TimerHelper.ExecuteAfterTimeAsync(2, () => _viewServices.Destroy(_bullet));
        }
    }
}
