using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Asteroids
{
    internal class GameService
    {
        private Player _player;

        public GameService(GameObject playerGameObject, GameObject background)
        {
            ServiceLocator.SetService<IViewServices>(new ViewServices());
            _player= UnityEngine.Object.Instantiate<GameObject>(playerGameObject).GetComponent<Player>();
            UnityEngine.Object.Instantiate<GameObject>(background, new Vector3(0, 0, 2), Quaternion.identity);
        }

        internal List<IFixedExecute> GetFixedUpdateObjects()
        {
            var inputController = new PlayerInputController(_player, Camera.main);
            return new List<IFixedExecute>() { inputController};
        }


        internal List<IExecute> GetUpdateObjects(string simpleEnemiesSpaunerParametersPath)
        {
            if (!File.Exists(simpleEnemiesSpaunerParametersPath))
                throw new ArgumentException("File does not exist");
            var simpleEnemiesSpaunerParameters = JsonConvert.DeserializeObject<SimpleEnemiesSpaunerParameters>(File.ReadAllText(simpleEnemiesSpaunerParametersPath));
            var enemiesSpauner = new SimpleEnemiesSpauner(new EnemyFactory(), simpleEnemiesSpaunerParameters);
            
            var inputController = new PlayerInputController(_player, Camera.main);
            return new List<IExecute>() { enemiesSpauner, inputController };
        }
    }
}