using TraineeManagementApi.Dto;

namespace TraineeManagementApi.Services;

public interface IFileStorageService
{
    Task<string> SaveAsync(IFormFile formFile);
    bool ExistsAsync(string filePath);
    bool DeleteAsync(string filePath);
}