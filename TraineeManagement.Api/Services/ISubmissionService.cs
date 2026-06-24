using TraineeManagement.Api.Dto;
using Shared.Models;

namespace TraineeManagement.Api.Services;

public interface ISubmissionService
{
    Task<List<Submission>> GetAllSubmissions();
    Task<Submission?> GetSubmissionById(int id);
    Task<SubmissionResponse> CreateSubmission(CreateSubmissionRequest submission);

    Task<string> UploadFile(int submissionId, CreateSubmissionFileRequest createSubmissionFileRequest, CancellationToken cancellationToken);

    Task<Submission?> GetSubmissionSummaryById(int id, CancellationToken cancellationToken);
}