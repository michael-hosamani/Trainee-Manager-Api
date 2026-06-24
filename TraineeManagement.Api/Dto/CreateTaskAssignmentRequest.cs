using Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace TraineeManagement.Api.Dto;

public class CreateTaskAssignmentRequest
{
    [Required(ErrorMessage = "TraineeId is required")]
    public int TraineeId { get; set; }

    [Required(ErrorMessage = "MentorId is required")]
    public int MentorId { get; set; }

    [Required(ErrorMessage = "LearningTaskId is required")]
    public int LearningTaskId { get; set; }

    [Required(ErrorMessage = "AssignedDate is required")]
    public DateTime AssignedDate { get; set; }

    [Required(ErrorMessage = "DueDate is required")]
    public DateTime DueDate { get; set; }

    [Required(ErrorMessage = "Status is required")]
    public TaskAssignmentStatus Status { get; set; }
    public string? Remarks { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (DueDate < AssignedDate)
        {
            yield return new ValidationResult(
                "Due Date cannot be earlier than Assigned Date.",
                new[] { nameof(DueDate) }
            );
        }
    }
}