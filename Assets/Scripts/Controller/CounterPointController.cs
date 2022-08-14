using System;

namespace Asteroids
{
    public class CounterPointController : ICounterPointController
    {
        private int fragsCount;
        private int pointCount;
        private MessageBroker messageBroker;

        public CounterPointController(MessageBroker messageBroker)
        {
            this.messageBroker = messageBroker;
        }

        public event Action<int> FragsCountChange;
        public event Action<int> PointCountChange;

        public void CountDeadEnemy(Type type)
        {
            ++fragsCount;
            FragsCountChange?.Invoke(fragsCount);
            //messageBroker.Publish("FragsCountChange", this.GetType().Name, fragsCount);

            if (type.Equals(typeof(UFO)))
            {
                pointCount += 1000;
            }
            if (type.Equals(typeof(Asteroid)))
            {
                pointCount += 250;
            }
            PointCountChange?.Invoke(pointCount);
            //messageBroker.Publish("PointCountChange", this.GetType().Name, pointCount);

        }
    }
}