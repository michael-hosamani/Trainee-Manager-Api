// Interface for TraineeService
using TraineeManagement.Api.Dto;
using TraineeManagement.Api.Helpers;
using TraineeManagement.Api.Models;

namespace TraineeManagement.Api.Services;

public interface ITraineeService
{
    Task<List<Trainee>> GetAllTrainees();
    Task<Trainee?> GetTraineeById(int id, CancellationToken cancellationToken);
    Task<TraineeResponse> CreateTrainee(CreateTraineeRequest trainee);
    Task<Trainee?> UpdateTraineeDetails(int id, UpdateTraineeRequest trainee, CancellationToken cancellationToken);
    Task<bool> DeleteTraineeDetails(int id, CancellationToken cancellationToken);

    Task<IQueryable<Trainee>> SearchTrainees(string search);
    Task<PagedResponse<Trainee>> GetTraineeUsingPagination(PaginationParams paginationParams, string? search, Status? status);
}