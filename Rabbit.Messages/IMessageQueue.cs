using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbit.Messages
{
    public interface IMessageQueue
    {
        string Queue { get; }
    }
}
