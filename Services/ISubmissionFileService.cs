using System.Reflection.Metadata;
using TraineeManagementApi.Models;

namespace TraineeManagementApi.Services;

public interface ISubmissionFileService
{
    Task<SubmissionFile> DownloadFile(int id);

    Task<bool> DeleteFile(int id);
}