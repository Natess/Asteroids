using UnityEngine;

namespace Asteroids
{
    internal class EnemyWeapon: IShooting
    {
        private IShooting _shootingImplementation;
        //private float _timerPeriod;
        //private bool _canShoot = true;
        public float Force => _shootingImplementation.Force;


        public EnemyWeapon(IShooting shooting)//, float timerPeriod)
        {
            _shootingImplementation = shooting;
            //_timerPeriod = timerPeriod;
        }

        public void Fire(Transform barrel)
        {
            //if(_canShoot)
            //{
            //_canShoot = false;
            _shootingImplementation.Fire(barrel);
            //TimerHelper.ExecuteAfterTimeAsync(_timerPeriod, () => _canShoot = true);
            //}
        }
    }
}