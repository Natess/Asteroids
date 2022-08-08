using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]private float _lifeTime;

        private float _timer;
        private IViewServices _viewService;

        private void Awake()
        {
            _timer = _lifeTime;
            _viewService = ServiceLocator.Resolve<IViewServices>();//ViewServicesFactory.Instance();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("PlayerBullet") && !collision.gameObject.CompareTag("Player"))
                Destroy();
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                Destroy();
            }
        }

        private void Destroy()
        {
            if (gameObject.activeSelf)
            {
                _viewService.Destroy(gameObject);
                _timer = _lifeTime;
            }
        }
    }
}