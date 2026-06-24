
using TraineeManagement.Api.Models;

namespace TraineeManagement.Api.Dto;

public class SubmissionResponse
{
    public int Id { get; set; }
    public required int TaskAssignmentId { get; set; }
    public required string SubmissionUrl { get; set; }
    public required string Notes { get; set; }
    public DateTime SubmissionDate { get; set; }
    public required SubmissionStatus Status { get; set; }
    public TaskAssignment TaskAssignment { get; set; } = null!;
}