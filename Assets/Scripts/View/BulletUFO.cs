using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    public class BulletUFO : MonoBehaviour
    {
        [SerializeField] private float _lifeTime;

        private float _timer;
        private IViewServices _viewService;

        private void Awake()
        {
            _timer = _lifeTime;
            _viewService = ViewServicesFactory.Instance();
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
