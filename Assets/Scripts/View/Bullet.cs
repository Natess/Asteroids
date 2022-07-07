using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Bullet : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("PlayerBullet") && !collision.gameObject.CompareTag("Player"))
                ViewServicesFactory.Instance().Destroy(gameObject);
        }
    }
}