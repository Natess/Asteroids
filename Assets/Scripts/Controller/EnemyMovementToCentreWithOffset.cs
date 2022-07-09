using UnityEngine;

namespace Asteroids
{
    internal class EnemyMovementToCentreWithOffset: IEnemyMovement
    {
        private const float OFFSET_FROM_CENTRE = 3f;
        private IMove _move;
        private Transform _transform;

        public EnemyMovementToCentreWithOffset(IMove move, Transform transform)
        {
            this._move = move;
            _transform = transform;
        }

        public void StartMove()
        {
            var horizontalOffset = Random.Range(-OFFSET_FROM_CENTRE, OFFSET_FROM_CENTRE);
            var verticalOffset = Random.Range(-OFFSET_FROM_CENTRE, OFFSET_FROM_CENTRE);

            _move.Move(-_transform.position.x - horizontalOffset, -_transform.position.y - verticalOffset, Time.deltaTime);
        }
    }
}
