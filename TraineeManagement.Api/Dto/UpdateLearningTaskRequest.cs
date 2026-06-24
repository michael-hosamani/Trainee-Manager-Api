using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Models;

namespace TraineeManagement.Api.Dto;
 
public class UpdateLearningTaskRequest
{   
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string?  ExpectedTechStack { get; set; }

    public DateTime? DueDate { get; set; }

    [EnumDataType(typeof(LearningTaskStatus), ErrorMessage = "Status must be valid")]
    public LearningTaskStatus? Status { get; set; }
}