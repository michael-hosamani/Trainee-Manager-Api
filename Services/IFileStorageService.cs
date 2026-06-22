using TraineeManagementApi.Dto;
using TraineeManagementApi.Models;

namespace TraineeManagementApi.Services;

public interface IFileStorageService
{
    Task<string> SaveAsync(IFormFile formFile, CancellationToken cancellationToken);
    DownloadFileType OpenReadAsync(SubmissionFile file, CancellationToken cancellationToken);
    bool ExistsAsync(string filePath, CancellationToken cancellationToken);
    bool DeleteAsync(string filePath, CancellationToken cancellationToken);
}