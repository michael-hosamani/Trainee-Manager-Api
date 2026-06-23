using TraineeManagementApi.Models;

namespace TraineeManagementApi.Services;

public interface IRabbitMQService
{
    Task PublishAsync(SubmissionProcessingRequested message);
}