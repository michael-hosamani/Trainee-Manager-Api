using Shared.Models;

namespace Shared.Dto;

public class TestResponseDto
{
    public required DummyTrainee Trainee { get; set; }
    public required Guid CorrelationId { get; set; }
}