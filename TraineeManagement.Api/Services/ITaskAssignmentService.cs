using TraineeManagement.Api.Dto;
using TraineeManagement.Api.Models;

namespace TraineeManagement.Api.Services;

public interface ITaskAssignmentService
{
    Task<List<TaskAssignment>> GetAllTaskAssignments();
    Task<TaskAssignment?> GetTaskAssignmentById(int id, CancellationToken cancellationToken);
    Task<TaskAssignmentResponse> CreateTaskAssignment(CreateTaskAssignmentRequest taskAssignment);
    Task<TaskAssignment?> UpdateTaskAssignmentDetails(int id, UpdateTaskAssignmentRequest updateTaskAssignmentRequest, CancellationToken cancellationToken);
}