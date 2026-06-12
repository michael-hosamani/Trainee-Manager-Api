using TraineeManagementApi.Models;

namespace TraineeManagementApi.Dto;

public class ReviewResponse
{
    public required int Id { get; set; }
    public required int SubmissionId { get; set; }
    public required int MentorId { get; set; }
    public required string Feedback { get; set; }
    public string? Score { get; set; }
    public required ReviewStatus Status { get; set; }
    public required DateTime ReviewedDate { get; set; }
    public Submission Submission { get; set; } = null!;
    public Mentor Mentor { get; set; } = null!;
}