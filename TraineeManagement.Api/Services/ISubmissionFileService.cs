using System.Reflection.Metadata;
using TraineeManagement.Api.Dto;
using TraineeManagement.Api.Models;

namespace TraineeManagement.Api.Services;

public interface ISubmissionFileService
{
    Task<DownloadFileType> DownloadFile(int id, CancellationToken cancellationToken);

    Task<bool> DeleteFile(int id, CancellationToken cancellationToken);
}