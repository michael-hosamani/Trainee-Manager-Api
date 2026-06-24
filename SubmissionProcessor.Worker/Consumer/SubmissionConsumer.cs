using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shared;
using System.Text;
using System.Text.Json;

namespace SubmissionProcessor.Worker.Consumer;
public class SubmissionConsumer : BackgroundService
{
    private IConnection? _connection;
    private IChannel? _channel;
    private readonly IConfiguration _configuration;

    public SubmissionConsumer(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        ConnectionFactory factory = new ConnectionFactory
        {
            HostName = _configuration["RabbitMQ:HostName"], 
            VirtualHost = _configuration["RabbitMQ:VirtualHost"],
            Port = int.Parse(_configuration["RabbitMQ:Port"]),
            UserName = _configuration["RabbitMQ:UserName"], 
            Password = _configuration["RabbitMQ:Password"] 
        };

        _connection = await factory.CreateConnectionAsync();
        _channel = await _connection.CreateChannelAsync();

        await _channel.QueueDeclareAsync(
            queue: _configuration["RabbitMQ:QueueName"] ,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null,
            cancellationToken: cancellationToken
        );

        await _channel.BasicQosAsync(
            prefetchSize: 0,
            prefetchCount: 1,
            global: false,
            cancellationToken: cancellationToken
        );

        var consumer = new AsyncEventingBasicConsumer(_channel);
        
        consumer.ReceivedAsync += async (ch, ea) =>
        {
            
            var body = ea.Body.ToArray();
           
            var message = Encoding.UTF8.GetString(body);
            var res = JsonSerializer.Deserialize<SubmissionProcessingRequested>(message);
            
            if(res == null)
            {
                _channel.BasicNackAsync(ea.DeliveryTag, false, true);
            }
            Console.WriteLine($"[x] Received: {message}");

            // Acknowledge message
            await _channel.BasicAckAsync(ea.DeliveryTag, multiple: false);
        };
        await _channel.BasicConsumeAsync(
            queue: _configuration["RabbitMQ:QueueName"],
            autoAck: false, 
            consumer: consumer,
            cancellationToken: cancellationToken
        );
    }
}