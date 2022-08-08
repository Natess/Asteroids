
using UnityEngine;

namespace Asteroids
{
    public class SimpleEnemiesSpauner : IExecute
    {
        private IEnemyFactory _factory;
        private SimpleEnemiesSpaunerParameters _parameters;

        private bool _isTimeCreateUfo = true;
        private bool _isTimeCreateAsteriod = true;

        public SimpleEnemiesSpauner(IEnemyFactory factory, SimpleEnemiesSpaunerParameters param)
        {
            _factory = factory;
            _parameters = param;
        }

        public void Update()
        {
            if (_isTimeCreateUfo)
            {
                _isTimeCreateUfo = false;
                var position = GetRandomPositionBetweenTwoRectangle();
                _factory.Create(EnemyTypes.UFO, new Health(_parameters.UFOHealth, _parameters.UFOHealth), position);
                TimerHelper.ExecuteAfterTimeAsync(_parameters.UfoTimeSpanPeriod, () => _isTimeCreateUfo = true);
            }

            if (_isTimeCreateAsteriod)
            {
                _isTimeCreateAsteriod = false;
                var position = GetRandomPositionBetweenTwoRectangle();
                _factory.Create((EnemyTypes)Random.Range(1, 3), new Health(_parameters.AsteroidHealth, _parameters.AsteroidHealth), position);
                TimerHelper.ExecuteAfterTimeAsync(_parameters.AsteroidTimeSpanPeriod, () => _isTimeCreateAsteriod = true);
            }
        }

        private Vector3 GetRandomPositionBetweenTwoRectangle()
        {
            var x = Random.Range(_parameters.CaptureDistanceMinX, _parameters.CaptureDistanceMaxX);
            x = Random.Range(-2, 2) >= 0 ? x : -x;

            float y;
            if(Mathf.Abs(x) > _parameters.CaptureDistanceMinX)
                y = Random.Range(-_parameters.CaptureDistanceMaxY, _parameters.CaptureDistanceMaxY);
            else
                y = Random.Range(_parameters.CaptureDistanceMinY, _parameters.CaptureDistanceMaxY);
            y = Random.Range(-2, 2) >= 0 ? y : -y;

            return new Vector3(x, y, 0);
        }

    }
}
