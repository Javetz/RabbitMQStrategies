using System;

namespace Rabbit.Messages
{
    public class EndOfGameMessage: IMessageQueue
    {
        public string Queue => "Bingo.EndOfGame";

        public EndOfGameMessage(DateTime reportDate)
        {
            ReportDate = reportDate;
        }

        public DateTime ReportDate { get; protected set; }

    }
}
