// Interface for TraineeService
using TraineeManagementApi.Dto;
using TraineeManagementApi.Helpers;
using TraineeManagementApi.Models;

namespace TraineeManagementApi.Services;

public interface ITraineeService
{
    Task<List<Trainee>> GetAllTrainees();
    Task<Trainee?> GetTraineeById(int id);
    Task<TraineeResponse> CreateTrainee(CreateTraineeRequest trainee);
    Task<Trainee?> UpdateTraineeDetails(int id, UpdateTraineeRequest trainee);
    Task<bool> DeleteTraineeDetails(int id);

    Task<IQueryable<Trainee>> SearchTrainees(string search);
    Task<PagedResponse<Trainee>> GetTraineeUsingPagination(PaginationParams paginationParams, string? search, Status? status);
}