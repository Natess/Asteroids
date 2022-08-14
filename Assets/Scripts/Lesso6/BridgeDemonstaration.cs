using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Lesson6
{
    public class BridgeDemonstaration : MonoBehaviour
    {
        [SerializeField] private Sprite _bulletSprite;

        void Start()
        {
            var ufo = Object.Instantiate(Resources.Load<UFO>("Enemy/UFO"), Vector3.zero, Quaternion.identity);

            var movement = new EnemyMovementToCentreWithOffset(new MovePhysics(ufo.GetComponent<Rigidbody2D>(), 5f), transform);
            var shooting = new UFOShootingShip(5, _bulletSprite, new GameObjectBuilder());
            var counterUIController = ControllerStaticFactory.GetCounterPointController();

            ufo.DependencyInjectBehaviour(movement, shooting, counterUIController);
        }
    }
}