using UnityEngine;

namespace Asteroids
{
    internal class UfoShootingController : IExecute
    {
        float _fireTimer = 0;
        private IShooting _ufoWeapon;
        private Transform _barrel;
        private float _fireTimerPeriod;

        public UfoShootingController(IShooting shooting, Transform barrel, float fireTimerPeriod)
        {
            this._ufoWeapon = shooting;
            this._barrel = barrel;
            this._fireTimerPeriod = fireTimerPeriod;
        }

        public void Update()
        {
            _fireTimer -= Time.deltaTime;
            if (_fireTimer < 0)
            {
                _ufoWeapon.Fire(_barrel);
                _fireTimer = _fireTimerPeriod;
            }
        }
    }
}
