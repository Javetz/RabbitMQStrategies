using System;

namespace RabbitWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var reciever = new Receive();
            reciever.ReceiveMessage();

            Console.ReadLine();
        }
    }
}
