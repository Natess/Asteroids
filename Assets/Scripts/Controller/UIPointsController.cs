using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    internal class UIPointsController
    {
        private UserInterface userInterface;

        public UIPointsController(UserInterface userInterface)
        {
            this.userInterface = userInterface;
        }
        internal void Subscribe(MessageBroker messageBroker)
        {
            messageBroker.Subscribe("FragsCountChange", onChangeFragsCount);
            messageBroker.Subscribe("PointCountChange", onChangePointsCount);
        }

        private void onChangePointsCount(MessageBase message)
        {
            if (message?.Data != null && message.Data is Nullable<int>)
            {
                userInterface.SetText(StateUI.PointCountPanel, $"Очки: {(int)message.Data}");
            }

        }

        private void onChangeFragsCount(MessageBase message)
        {
            if (message?.Data != null && message.Data is Nullable<int>)
            {
                userInterface.SetText(StateUI.FragsCountPanel, $"Уничтожено: {(int)message.Data}");
            }
        }

        public void onChangeFragsCount(int count)
        {
            userInterface.SetText(StateUI.FragsCountPanel, $"Уничтожено: {count}");
        }

        public void onChangePointsCount(int count)
        {
            userInterface.SetText(StateUI.PointCountPanel, $"Очки: {count}");
        }

    }
}
