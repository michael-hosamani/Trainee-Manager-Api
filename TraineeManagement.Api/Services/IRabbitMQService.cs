using TraineeManagement.Api.Models;

namespace TraineeManagement.Api.Services;

public interface IRabbitMQService
{
    Task PublishAsync(SubmissionProcessingRequested message);
}