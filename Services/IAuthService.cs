using TraineeManagementApi.Dto;

namespace TraineeManagementApi.Services;

public interface IAuthService
{
    Task<LoginResponse?> UserLogin(LoginRequest loginRequest);
    LoginResponse? refreshToken(RefreshTokenDto refreshToken);
}