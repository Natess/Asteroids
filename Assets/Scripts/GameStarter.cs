using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Asteroids
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private GameObject _playerGameObject;
        [SerializeField] private GameObject _background;
        [SerializeField] private GameObject _abilityUFO;

        private List<IExecute> _updateObjects = new List<IExecute>();
        private GameService gameService;
        private List<IFixedExecute> _fixedUpdateObjects = new List<IFixedExecute>();

        private void Awake()
        {
            gameService = new GameService(_playerGameObject, _background, gameObject.GetComponent<UserInterface>());

            _fixedUpdateObjects = gameService.GetFixedUpdateObjects();
            _updateObjects = gameService.GetUpdateObjects(Path.Combine(Application.dataPath, "Parameters/SimpleEnemiesSpaunerParameters.txt"));
        }

        void Update()
        {
            for (int i = 0; i < _updateObjects.Count; i++)
            {
                IExecute item = _updateObjects[i];
                if (item == null)
                    continue;

                item.Update();
            }
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < _fixedUpdateObjects.Count; i++)
            {
                IFixedExecute item = _fixedUpdateObjects[i];
                if (item == null)
                    continue;

                item.FixedUpdate();
            }
        }
    }

}
