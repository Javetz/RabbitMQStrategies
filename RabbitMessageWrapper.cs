using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbit.Messages
{
    public class RabbitMessageWrapper : IRabbitMessageWrapper, IMessageQueue
    {
        public Type MessageType { get; protected set; }

        public string JSonMessage { get; protected set; }

        public string Queue { get; protected set; }

        public RabbitMessageWrapper(string messageType, string jsonMessage, string queue)
        {
            MessageType = Type.GetType(messageType, true, true);
            JSonMessage = jsonMessage;
            Queue = queue;
        }
    }
}
