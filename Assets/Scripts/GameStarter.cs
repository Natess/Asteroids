using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class GameStarter : MonoBehaviour
    {
        private List<IExecute> _interactiveObjects = new List<IExecute>();
        private SimpleEnemiesSpauner _enemiesSpauner;

        private void Start()
        {
            //Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));

            //IEnemyFactory factory = new EnemyFactory();
            //factory.Create(EnemyTypes.Asteroid2, new Health(100.0f, 100.0f));

            //Enemy.Factory = factory;
            //Enemy.Factory.Create(EnemyTypes.UFO, new Health(100.0f, 100.0f));
        }
        
        private void Awake()
        {
            _enemiesSpauner = new SimpleEnemiesSpauner(new EnemyFactory(), new SimpleEnemiesSpaunerParameters()
            {
                AsteroidTimePeriod = 4,
                UfoTimePeriod = 7,
                CaptureDistanceMaxX = 10,
                CaptureDistanceMinX = 9,
                CaptureDistanceMaxY = 6,
                CaptureDistanceMinY = 5,
                UFOHealth = 2,
                AsteroidHealth = 1
            });
            _interactiveObjects.Add(_enemiesSpauner);
        }

        void Update()
        {
            foreach (IExecute item in _interactiveObjects)
            {
                if (item == null)
                    continue;

                item.Update();
            }
        }
    }

}
