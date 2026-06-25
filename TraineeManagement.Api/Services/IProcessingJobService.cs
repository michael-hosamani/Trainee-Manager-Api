using Shared.Models;

namespace TraineeManagement.Api.Services;

public interface IProcessingJobService
{
    Task<ProcessingJob?> GetById(int id);
}