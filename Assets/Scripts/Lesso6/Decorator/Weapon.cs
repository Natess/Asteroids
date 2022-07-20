using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids.Lesson6
{
    internal sealed class Weapon : IFire
    {
        private readonly AudioSource _audioSource;
        internal AudioClip AudioClip { get; private set; }
        internal Transform BarrelPosition { get; private set; }

        private IAmmunition _bullet;
        private float _force;

        public Weapon(IAmmunition bullet, Transform barrelPosition, float force,
                        AudioSource audioSource, AudioClip audioClip)
        {
            _audioSource = audioSource;
            AudioClip = audioClip;
            _bullet = bullet;
            BarrelPosition = barrelPosition;
            _force = force;
        }

        public void SetBarrelPosition(Transform barrelPosition)
        {
            BarrelPosition = barrelPosition;
        }

        public void SetBullet(IAmmunition bullet)
        {
            _bullet = bullet;
        }

        public void SetForce(float force)
        {
            _force = force;
        }

        public void SetAudioClip(AudioClip audioClip)
        {
            AudioClip = audioClip;
        }

        public void Fire()
        {
            var bullet = UnityEngine.Object.Instantiate(_bullet.BulletInstance, BarrelPosition.position, Quaternion.identity);
            bullet.AddForce(BarrelPosition.forward * _force);
            UnityEngine.Object.Destroy(bullet.gameObject, _bullet.TimeToDestroy);
            _audioSource.PlayOneShot(AudioClip);
        }
    }

}
