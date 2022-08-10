using UnityEngine;

namespace Asteroids
{
    [System.Serializable]
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected float _lifeTime = 20;
      
        protected IEnemyMovement _movement;
        protected IEnemyHealth _health;
        protected CounterPointController _counterUIController;

        // Фабрика
        public static IEnemyFactory Factory;

        // Фабричный метод (для примера)
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

        protected virtual void CheckDead()
        {
            if (_health.HP.Current <= 0)
            {
                _counterUIController.CountDeadEnemy(this.GetType());
            }
        }

    }
}