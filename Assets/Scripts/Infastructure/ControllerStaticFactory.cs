using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    internal static class ControllerStaticFactory
    {
        public readonly static MessageBroker MessageBroker = new MessageBroker();

        private static CounterPointController counterPointsController;
        public static CounterPointController GetCounterPointController()
        {
            if (counterPointsController == null)
                counterPointsController = new CounterPointController(MessageBroker);
            return counterPointsController;
        }

        private static UIPointsController uiPointsController;

        internal static UIPointsController GetUIPointsController(UserInterface userInterface)
        {
            if (uiPointsController == null)
                uiPointsController = new UIPointsController(userInterface);

            return uiPointsController;
        }

        private static TimeRewindController timeRewindController;
        internal static TimeRewindController GetPlayerTimeRewardController(Rigidbody2D rigidbody)
        {
            if (timeRewindController == null)
                timeRewindController = new TimeRewindController(rigidbody, 5f);

            return timeRewindController;
        }

        private static PlayerInputController playerInputController;

        internal static PlayerInputController GetPlayerInputController(Player player, Camera main)
        {
            if (playerInputController == null)
                playerInputController = new PlayerInputController(player, main, GetPlayerTimeRewardController(player.GetComponent<Rigidbody2D>()));

            return playerInputController;
        }
    }
}
