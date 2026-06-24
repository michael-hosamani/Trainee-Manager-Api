using TraineeManagementApi.Dto;
using TraineeManagementApi.Models;

namespace TraineeManagementApi.Services;

public interface ITaskAssignmentService
{
    Task<List<TaskAssignment>> GetAllTaskAssignments();
    Task<TaskAssignment?> GetTaskAssignmentById(int id, CancellationToken cancellationToken);
    Task<TaskAssignmentResponse> CreateTaskAssignment(CreateTaskAssignmentRequest taskAssignment);
    Task<TaskAssignment?> UpdateTaskAssignmentDetails(int id, UpdateTaskAssignmentRequest updateTaskAssignmentRequest, CancellationToken cancellationToken);
}