using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
namespace RabbitMqDemo.Services
{
    public class MessageConsumer : BackgroundService
    {
        private readonly IConfiguration
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // ConnectionFactory factory = new ConnectionFactory
            // {
            //     HostName = _configuration["RabbitMQ:HostName"], 
            //     VirtualHost = _configuration["RabbitMQ:VirtualHost"],
            //     Port = int.Parse(_configuration["RabbitMQ:Port"]),
            //     UserName = _configuration["RabbitMQ:UserName"], 
            //     Password = _configuration["RabbitMQ:Password"] 
            // };
            ConnectionFactory factory = new ConnectionFactory
            {
                HostName = "localhost", 
                VirtualHost = "/",
                Port = 5672,
                UserName = "admin",  
                Password = "rabbitmq_password" 
            };

            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: _configuration["RabbitMQ:QueueName"],
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var consumer = await new EventingBasicConsumerAsync(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received: {message}");
            };
            channel.BasicConsume(queue: "submission-processing",
                                 autoAck: true,
                                 consumer: consumer);
            return Task.CompletedTask;
        }
    }
}