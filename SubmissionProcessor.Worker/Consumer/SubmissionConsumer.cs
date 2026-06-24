using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shared.Data;
using Shared.Models;
using System.Text;
using System.Text.Json;

namespace SubmissionProcessor.Worker.Consumer;
public class SubmissionConsumer : BackgroundService
{
    private IConnection? _connection;
    private IChannel? _channel;
    private readonly IConfiguration _configuration;
    private readonly AppDbContext _db;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public SubmissionConsumer(IConfiguration configuration, AppDbContext db, IServiceScopeFactory serviceScopeFactory)
    {
        _configuration = configuration;
        _db = db;
        _serviceScopeFactory = serviceScopeFactory;
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
                // return Task.CompletedTask;
            }

            // ProcessingJob job = await _db.ProcessingJobs.FindAsync(res.CorrelationId);
            // job.status = ProcessingJobStatus.Processing;
            // await _db.SaveChangesAsync();
            this.UpdateStatus(res, ProcessingJobStatus.Processing);

            //TODO: simulate job processing 

            // Acknowledge message
            await _channel.BasicAckAsync(ea.DeliveryTag, multiple: false);

            // job.status = ProcessingJobStatus.Completed;
            // await _db.SaveChangesAsync();
            this.UpdateStatus(res, ProcessingJobStatus.Completed);
        };
        await _channel.BasicConsumeAsync(
            queue: _configuration["RabbitMQ:QueueName"],
            autoAck: false, 
            consumer: consumer,
            cancellationToken: cancellationToken
        );

        // return;
    }

    public async Task UpdateStatus(SubmissionProcessingRequested payload, ProcessingJobStatus status, string ErrorMessage = "default", CancellationToken cancellationToken = default)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            Guid CorrelationId =  payload.CorrelationId;
            AppDbContext _dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
 
            ProcessingJob? job = await _dbContext.ProcessingJobs.FindAsync(payload.CorrelationId) ?? throw new Exception("Processing JOB not found");
           
            //When Processing
            if (status == ProcessingJobStatus.Processing)
            {
                if (job.status == ProcessingJobStatus.Completed) {
                    throw new InvalidOperationException($"Job Process with Correlation Id Already Processed {CorrelationId}");
                }
 
                job.status = status;
                job.Attempts++;
            }
            if (status == ProcessingJobStatus.Completed)
            {
                job.status = status;
                job.CompletedAt = DateTime.UtcNow;
            }
            if (status == ProcessingJobStatus.Failed)
            {
                job.status = status;
                job.ErrorSummary = ErrorMessage;
            }
           
            await _dbContext.SaveChangesAsync(cancellationToken);
        };
    }
}