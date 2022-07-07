using UnityEngine;

namespace Asteroids
{
    internal class RandomEnemyMovement: IEnemyMovement
    {
        private IMove _move;
        private Transform _transform;

        public RandomEnemyMovement(IMove move, Transform transform)
        {
            this._move = move;
            _transform = transform;
        }

        public void StartMove()
        {
            var horizontal = Random.Range(-3f, 3f);
            var vertical = Random.Range(-3f, 3f);
            _move.Move(-_transform.position.x - horizontal, -_transform.position.y - vertical, Time.deltaTime);
        }
    }
}
