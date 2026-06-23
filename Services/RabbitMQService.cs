using RabbitMQ.Client;
using System.Reflection;
using System.Text;
using System.Text.Json;
using TraineeManagementApi.Models;

namespace TraineeManagementApi.Services;

public class RabbitMQService: IRabbitMQService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<RabbitMQService> _logger;

    public RabbitMQService(IConfiguration configuration, ILogger<RabbitMQService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public async Task PublishAsync(SubmissionProcessingRequested message)
    {
        ConnectionFactory factory = new ConnectionFactory
        {
            HostName = _configuration["RabbitMQ:HostName"], 
            VirtualHost = _configuration["RabbitMQ:VirtualHost"],
            Port = int.Parse(_configuration["RabbitMQ:Port"]),
            UserName = _configuration["RabbitMQ:UserName"], 
            Password = _configuration["RabbitMQ:Password"] 
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

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

        var properties = new BasicProperties{
            Persistent=true,
            MessageId=message.MessageId.ToString(),
            CorrelationId=message.CorrelationId.ToString(),
            ContentType="application/json",
            Type=nameof(SubmissionProcessingRequested)
        };

        await channel.BasicPublishAsync(
            exchange: "",
            routingKey: _configuration["RabbitMQ:QueueName"],
            mandatory: true,
            basicProperties: properties,
            body: body
        );

        _logger.LogInformation("RabbitMQ publish success. Message Id = {MessageId}, CorrelationId = {correlationId}, SubmissionId = {SubmissionId}, FileId = {FileId}",
            message.MessageId,
            message.CorrelationId,
            message.SubmissionId,
            message.FileId        
        );
    }
}