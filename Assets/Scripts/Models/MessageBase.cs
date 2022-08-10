using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    public class MessageBase
    {
        public string Sender { get; private set; } // отправитель
        public int Id { get; private set; } // id сообщения
        public System.Object Data { get; private set; } // данные

        public MessageBase(string sender, int id, System.Object data)
        {
            this.Sender = sender;
            this.Id = id;
            this.Data = data;
        }

        public static MessageBase Create(string sender,
            int id, System.Object data)
        {
            return new MessageBase(sender, id, data);
        }
    }
}
