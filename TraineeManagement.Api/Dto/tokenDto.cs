namespace TraineeManagement.Api.Dto;

public enum AuthTokenType{
    AccessToken,
    RefreshToken
}

public class GenerateTokenResult {
    public required string jwt { get; set; }
    public required DateTime expiryDate { get; set; }
}