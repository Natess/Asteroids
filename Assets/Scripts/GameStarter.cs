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

            ChainOfResponsibilityExample();
            IteratorExample();
        }

        private void IteratorExample()
        {
            var ability = new List<IAbility>
            {
                new Ability("Inner Fire", 100, Target.None, DamageType.Magical),
                new Ability("Burning Spear", 200, Target.Unit | Target.Autocast, DamageType.Magical),
                new Ability("Berserker's Blood", 300, Target.Passive, DamageType.None),
                new Ability("Life Break", 400, Target.Unit, DamageType.Magical),
            };

            IAbilityEnemy enemy = new UfoWithAbility(ability);
            Debug.Log(enemy[0]);
            Debug.Log(new string('+', 50));
            Debug.Log(enemy[Target.Unit | Target.Autocast]);
            Debug.Log(new string('+', 50));
            Debug.Log(enemy[Target.Unit | Target.Passive]);
            Debug.Log(new string('+', 50));
            Debug.Log(enemy.MaxDamage);
            Debug.Log(new string('+', 50));
            foreach (var o in enemy)
            {
                Debug.Log(o);
            }

            Debug.Log(new string('+', 50));
            foreach (var o in enemy.GetAbility().Take(2))
            {
                Debug.Log(o);
            }

            Debug.Log(new string('+', 50));
            foreach (var o in enemy.GetAbility(DamageType.Magical))
            {
                Debug.Log(o);
            }

        }

        void ChainOfResponsibilityExample()
        {
            var player = gameService.Player;
            var root = new PlayerModifier(player);
            root.Add(new AddSpeedModifier(player, 1));
            root.Add(new AddHealthModifier(player, 1));
            root.Handle();
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
