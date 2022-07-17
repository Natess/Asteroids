using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private Player _playerGameObject;

        // Настройки игры
        [SerializeField] private float _asteroidTimeSpanPeriod = 4;
        [SerializeField] private float _ufoTimeSpanPeriod = 7;
        [SerializeField] private float _сaptureDistanceMaxX = 10;
        [SerializeField] private float _сaptureDistanceMinX = 9;
        [SerializeField] private float _сaptureDistanceMaxY = 6;
        [SerializeField] private float _сaptureDistanceMinY = 5;
        [SerializeField] private int _ufoHealth = 2;
        [SerializeField] private int _asteroidHealth = 1;

        private List<IExecute> _updateObjects = new List<IExecute>();
        private List<IFixedExecute> _fixedUpdateObjects = new List<IFixedExecute>();

        private PlayerInputController _inputController;
        private SimpleEnemiesSpauner _enemiesSpauner;

        private void Awake()
        {
            ServiceLocatorInit();
            _inputController = new PlayerInputController(_playerGameObject, Camera.main);
            _fixedUpdateObjects.Add(_inputController);

            _enemiesSpauner = new SimpleEnemiesSpauner(new EnemyFactory(), new SimpleEnemiesSpaunerParameters()
            {
                AsteroidTimeSpanPeriod = _asteroidTimeSpanPeriod,
                UfoTimeSpanPeriod = _ufoTimeSpanPeriod,
                CaptureDistanceMaxX = _сaptureDistanceMaxX,
                CaptureDistanceMinX = _сaptureDistanceMinX,
                CaptureDistanceMaxY = _сaptureDistanceMaxY,
                CaptureDistanceMinY = _сaptureDistanceMinY,
                UFOHealth = _ufoHealth,
                AsteroidHealth = _asteroidHealth
            });
            _updateObjects.Add(_enemiesSpauner);
        }

        private void ServiceLocatorInit()
        {
            ServiceLocator.SetService<IViewServices>(new ViewServices());
        }

        void Update()
        {
            foreach (IExecute item in _updateObjects)
            {
                if (item == null)
                    continue;

                item.Update();
            }
        }

        private void FixedUpdate()
        {
            foreach (IFixedExecute item in _fixedUpdateObjects)
            {
                if (item == null)
                    continue;

                item.FixedUpdate();
            }
        }
    }

}
