using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public class MessageBroker : IMessageBroker<MessageBase>
    {
        private int id = 0;
        private readonly Dictionary<string, List<Action<MessageBase>>> subscribers
            = new Dictionary<string, List<Action<MessageBase>>>();

        public void Dispose()
        {
            subscribers?.Clear();
        } 

        public void Publish<T>(string topic, string sender, T data)
        {
            if (sender == null || data == null || !subscribers.ContainsKey(topic))
                return;

            var delegates = subscribers[topic];
            if (delegates == null || delegates.Count == 0) return;

            foreach (var handler in delegates)
            {
                handler?.Invoke(new MessageBase(sender, id++, data));
            }
        }

        public void Subscribe(string topic, Action<MessageBase> subscription)
        {
            var delegates = subscribers.ContainsKey(topic) ?
                            subscribers[topic] : new List<Action<MessageBase>>();
            if (!delegates.Contains(subscription))
            {
                delegates.Add(subscription);
            }
            subscribers[topic] = delegates;
        }

        public void Unsubscribe(string topic, Action<MessageBase> subscription)
        {
            if (subscribers[topic] == null)
                return;

            var delegates = subscribers[topic];
            if (delegates.Contains(subscription))
                delegates.Remove(subscription);
            if (delegates.Count == 0)
                subscribers.Remove(topic);
        }
    }
}
