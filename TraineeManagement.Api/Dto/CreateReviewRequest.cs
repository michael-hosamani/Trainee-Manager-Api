using System.ComponentModel.DataAnnotations;
using Shared.Models;

namespace TraineeManagement.Api.Dto;

public class CreateReviewRequest
{   
    [Required(ErrorMessage = "SubmissionId is required")]
    public required int SubmissionId { get; set; }

    [Required(ErrorMessage = "MentorId is required")]
    public required int MentorId { get; set; }

    [Required(ErrorMessage = "Feedback is required")]
    public required string Feedback { get; set; }

    public string? Score { get; set; }

    [Required(ErrorMessage = "Status is required")]
    [EnumDataType(typeof(ReviewStatus), ErrorMessage = "Status must be valid")]
    public required ReviewStatus Status { get; set; }

    [Required(ErrorMessage = "Review Date is required")]
    public required DateTime ReviewedDate { get; set; }
}