using System.Reflection.Metadata;
using TraineeManagementApi.Dto;
using TraineeManagementApi.Models;

namespace TraineeManagementApi.Services;

public interface ISubmissionFileService
{
    Task<DownloadFileType> DownloadFile(int id, CancellationToken cancellationToken);

    Task<bool> DeleteFile(int id, CancellationToken cancellationToken);
}