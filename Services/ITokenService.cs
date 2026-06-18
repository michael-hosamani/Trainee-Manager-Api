using TraineeManagementApi.Dto;
using TraineeManagementApi.Models;

namespace TraineeManagementApi.Services;

public interface ITokenService {
    public GenerateTokenResult GenerateToken(User user, AuthTokenType tokenType);
}