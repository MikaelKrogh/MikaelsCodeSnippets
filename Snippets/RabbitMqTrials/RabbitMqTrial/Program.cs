using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMqTrial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionFactory = new ConnectionFactory { 
                Uri = new Uri("amqp://guest:guest@localhost:5672") };

            using var connection = connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("demo-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
            var message = new {Name = "Producer", Message = "Hello There"};
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            channel.BasicPublish("", "demo-queue-key", null, body);
        }
    }
}