using System;
using UnityEngine;

namespace Asteroids
{
    [System.Serializable]
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] protected float _lifeTime = 20;
      
        protected IEnemyMovement _movement;
        protected IEnemyHealth _health;
        protected ICounterPointController _counterController;
        protected IFieldOfViewVisitor visitor;

        public event Action<Type> OnEnemyDead;

        public void DependencyInjectHealth(Health hp)
        {
            _health = new EnemyHealth(hp, gameObject);
            _health.OnDead += OnDead;
        }

        private void OnDead()
        {
            OnEnemyDead?.Invoke(this.GetType());
        }

        private void OnDestroy()
        {
            _health.OnDead -= OnDead;

        }
        protected abstract void OnBecameVisible();
    }
}