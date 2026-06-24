using TraineeManagement.Api.Dto;
using TraineeManagement.Api.Models;

namespace TraineeManagement.Api.Services;

public interface ILearningTaskService
{
    Task<List<LearningTask>> GetAllLearningTasks();
    Task<LearningTask?> GetLearningTaskById(int id);
    Task<LearningTaskResponse> CreateLearningTask(CreateLearningTaskRequest learningTask);
    Task<LearningTask?> UpdateLearningTaskDetails(int id, UpdateLearningTaskRequest learningTask);
    Task<bool> DeleteLearningTaskDetails(int id);
}