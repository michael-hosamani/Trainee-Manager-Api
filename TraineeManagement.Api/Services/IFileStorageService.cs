using TraineeManagement.Api.Dto;
using TraineeManagement.Api.Models;

namespace TraineeManagement.Api.Services;

public interface IFileStorageService
{
    Task<string> SaveAsync(IFormFile formFile, CancellationToken cancellationToken);
    DownloadFileType OpenReadAsync(SubmissionFile file, CancellationToken cancellationToken);
    bool ExistsAsync(string filePath, CancellationToken cancellationToken);
    bool DeleteAsync(string filePath, CancellationToken cancellationToken);
}