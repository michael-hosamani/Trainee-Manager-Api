using TraineeManagementApi.Dto;

namespace TraineeManagementApi.Services;

public interface IAuthService
{
    Task<LoginResponse?> Login(LoginRequest loginRequest);
}