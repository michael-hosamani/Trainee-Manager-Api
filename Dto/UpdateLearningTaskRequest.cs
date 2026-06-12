using System.ComponentModel.DataAnnotations;
using TraineeManagementApi.Models;

namespace TraineeManagementApi.Dto;
 
public class UpdateLearningTaskRequest
{   
    [Required(ErrorMessage = "Learning task title is required")] 
    public required string? Title { get; set; }

    [Required(ErrorMessage = "Learning task description is required")] 
    public required string? Description { get; set; }

    [Required(ErrorMessage = "Expected tech stack is required")] 
    public required string?  ExpectedTechStack { get; set; }

    [Required(ErrorMessage = "Due date is required")] 
    public required DateTime? DueDate { get; set; }

    [Required(ErrorMessage = "Status is required")]
    [EnumDataType(typeof(LearningTaskStatus), ErrorMessage = "Status must be valid")]
    public required LearningTaskStatus? Status { get; set; }
}