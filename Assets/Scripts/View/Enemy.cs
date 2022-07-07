using UnityEngine;

namespace Asteroids
{
    public abstract class Enemy : MonoBehaviour
    {
        // �������
        public static IEnemyFactory Factory;

        protected IEnemyMovement _movement;
        protected IEnemyHealth _health;

        // ��������� ����� 
        public static Asteroid CreateAsteroidEnemy(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid1"));
            enemy._health = new EnemyHealth(hp, enemy.gameObject);

            return enemy;
        }

        public void DependencyInjectHealth(Health hp)
        {
            _health = new EnemyHealth(hp, gameObject);
        }

    }
}