using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids.Lesson6
{
    internal class DecoratorExample : MonoBehaviour
    {
        private IFire _fire;

        [Header("Start Gun")]
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        [Header("Muffler Gun")]
        [SerializeField] private AudioClip _audioClipMuffler;
        [SerializeField] private float _volumeFireOnMuffler;
        [SerializeField] private Transform _barrelPositionMuffler;
        [SerializeField] private GameObject _muffler;
        private Weapon weapon;
        private IMuffler muffler;
        private ModificationMuffler modificationWeapon;
        private bool hasMuffler = false;

        private void Start()
        {
            IAmmunition ammunition = new Bullet(_bullet, 3.0f);
            weapon = new Weapon(ammunition, _barrelPosition, 999.0f, _audioSource, _audioClip);
            muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler, _barrelPosition, _muffler);
            modificationWeapon = new ModificationMuffler(_audioSource, muffler, _barrelPositionMuffler.position);

            _fire = weapon;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (!hasMuffler)
                {
                    modificationWeapon.ApplyModification(weapon);
                    _fire = modificationWeapon;
                }
                else
                {
                    modificationWeapon.RemoveModification(weapon);
                    _fire = weapon;
                }

                hasMuffler = !hasMuffler;
            }

            if (Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
            }
        }
    }
}
