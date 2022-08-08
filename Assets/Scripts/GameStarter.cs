using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Asteroids
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private GameObject _playerGameObject;
        [SerializeField] private GameObject _background;

        private List<IExecute> _updateObjects = new List<IExecute>();
        private List<IFixedExecute> _fixedUpdateObjects = new List<IFixedExecute>();

        private void Awake()
        {
            var gameService = new GameService(_playerGameObject, _background);

            _fixedUpdateObjects = gameService.GetFixedUpdateObjects();
            _updateObjects = gameService.GetUpdateObjects(Path.Combine(Application.dataPath, "Parameters/SimpleEnemiesSpaunerParameters.txt"));
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
