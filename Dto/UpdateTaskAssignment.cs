using TraineeManagementApi.Models;
using System.ComponentModel.DataAnnotations;

namespace TraineeManagementApi.Dto;

public class UpdateTaskAssignmentRequest
{
    public int? TraineeId { get; set; }

    public int? MentorId { get; set; }

    public int? LearningTaskId { get; set; }

    public DateTime? AssignedDate { get; set; }

    public DateTime? DueDate { get; set; }

    public TaskAssignmentStatus? Status { get; set; }
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