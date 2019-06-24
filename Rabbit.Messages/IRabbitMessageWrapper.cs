using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbit.Messages
{
    public interface IRabbitMessageWrapper
    {
        Type MessageType { get; }

        string JSonMessage { get; }
    }
}
