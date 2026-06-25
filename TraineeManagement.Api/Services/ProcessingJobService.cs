using Shared.Data;
using Shared.Models;

namespace TraineeManagement.Api.Services;

public class ProcessingJobService : IProcessingJobService
{
    private readonly AppDbContext _db;
    private readonly ILogger<ProcessingJobService> _logger;

    public ProcessingJobService(AppDbContext db, ILogger<ProcessingJobService> logger)
    {
        _db = db;
        _logger = logger;
    }
    public async Task<ProcessingJob?> GetById(int id)
    {
        ProcessingJob? processingJob = await _db.ProcessingJobs.FindAsync(id);

        if(processingJob == null)
        {
            _logger.LogWarning("Processing Job not found with {id}", id);
            return null;
        }

        return processingJob;
    }
}