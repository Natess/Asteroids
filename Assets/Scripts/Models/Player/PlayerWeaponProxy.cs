using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    internal class PlayerWeaponProxy : IShooting
    {
        private readonly IShooting _weapon;
        private readonly UnlockWeapon _unlockWeapon;

        public float Force => _weapon.Force;
        public PlayerWeaponProxy(IShooting weapon, UnlockWeapon unlockWeapon)
        {
            _weapon = weapon;
            _unlockWeapon = unlockWeapon;
        }

        public void Fire(Transform barrel)
        {
            if (_unlockWeapon.IsUnlock)
            {
                _weapon.Fire(barrel);
            }
            else
            {
                Debug.Log("Weapon is lock");
            }
        }

        internal void SwitchWeapon()
        {
            _unlockWeapon.IsUnlock = !_unlockWeapon.IsUnlock;
        }
    }

}
