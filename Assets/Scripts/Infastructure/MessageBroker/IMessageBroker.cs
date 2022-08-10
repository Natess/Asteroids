using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public interface IMessageBroker<T> : IDisposable
    {
        void Publish<T1>(string topic, string sender, T1 data);
        void Subscribe(string topic, Action<T> subscription);
        void Unsubscribe(string topic, Action<T> subscription);
    } 
}
