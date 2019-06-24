using Newtonsoft.Json;
using Rabbit.Messages;
using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Testing WrappedMessage
            var endOfGameMessage = new EndOfGameMessage(DateTime.Now);
            var jsonMessage = JsonConvert.SerializeObject(endOfGameMessage);
            var rabbitMessageWrapper = new RabbitMessageWrapper(endOfGameMessage.GetType().ToString(), jsonMessage, endOfGameMessage.Queue);
            var wrappedJsonMessage = JsonConvert.SerializeObject(rabbitMessageWrapper);

            //Deserialising Message from queue
            var deserialisedMessage = JsonConvert.DeserializeObject<RabbitMessageWrapper>(wrappedJsonMessage);
            var wrappedMessageType = deserialisedMessage.MessageType;
            var wrappedDeserialisedMessage = JsonConvert.DeserializeObject(deserialisedMessage.JSonMessage, wrappedMessageType);


            var factory = new ConnectionFactory() { HostName = "192.168.50.20" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "task_queue",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var message = wrappedJsonMessage;// GetMessage(args);
                var body = Encoding.UTF8.GetBytes(message);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange: "",
                                     routingKey: "task_queue",
                                     basicProperties: properties,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}
