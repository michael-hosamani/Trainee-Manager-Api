using TraineeManagementApi.Models;

namespace TraineeManagementApi.Dto;
 
public class LearningTaskResponse
{
    public int Id { get; set; } 
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string  ExpectedTechStack { get; set; }
    public required DateTime DueDate { get; set; }
    public required LearningTaskStatus Status { get; set; }
    public DateTime CreatedDate { get; set; } 
    public DateTime UpdatedDate { get; set; } 
}