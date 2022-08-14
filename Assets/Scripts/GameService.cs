using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Asteroids
{
    internal class GameService
    {
        private GameObject _playerGameObject;
        internal Player Player;

        public GameService(GameObject playerGameObject, GameObject background, UserInterface userInterface)
        {
            ServiceLocator.SetService<IViewServices>(new ViewServices());
            _playerGameObject = UnityEngine.Object.Instantiate<GameObject>(playerGameObject);
            Player = _playerGameObject.GetComponent<Player>();
            UnityEngine.Object.Instantiate<GameObject>(background, new Vector3(0, 0, 2), Quaternion.identity);

            SetUIControllers(userInterface);
        }

        private void SetUIControllers(UserInterface userInterface)
        {
            var counter = ControllerStaticFactory.GetCounterPointController();
            var ui = ControllerStaticFactory.GetUIPointsController(userInterface);
            //ui.Subscribe(ControllerStaticFactory.MessageBroker);

            counter.PointCountChange += ui.onChangePointsCount;
            counter.FragsCountChange += ui.onChangeFragsCount;
        }

        internal List<IFixedExecute> GetFixedUpdateObjects()
        {
            var inputController = ControllerStaticFactory.GetPlayerInputController(Player, Camera.main);
            var timeRewardController = ControllerStaticFactory.GetPlayerTimeRewardController(_playerGameObject.GetComponent<Rigidbody2D>());
            return new List<IFixedExecute>() { inputController, timeRewardController};
        }

        internal List<IExecute> GetUpdateObjects(string simpleEnemiesSpaunerParametersPath)
        {
            if (!File.Exists(simpleEnemiesSpaunerParametersPath))
                throw new ArgumentException("File does not exist");
            var simpleEnemiesSpaunerParameters = JsonConvert.DeserializeObject<SimpleEnemiesSpaunerParameters>(File.ReadAllText(simpleEnemiesSpaunerParametersPath));
            var enemiesSpauner = new SimpleEnemiesSpauner(new EnemyFactory(), simpleEnemiesSpaunerParameters);
            
            var inputController = ControllerStaticFactory.GetPlayerInputController(Player, Camera.main);
            return new List<IExecute>() { enemiesSpauner, inputController };
        }
    }
}