namespace TraineeManagementApi.Models;
 
public class Mentor
{
    public int Id { get; set; } 
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string  Expertise { get; set; }
    public required MentorStatus Status { get; set; }
    public DateTime CreatedDate { get; set; } 
    public DateTime UpdatedDate { get; set; } 
    public ICollection<TaskAssignment> TaskAssignments { get; set; } = new List<TaskAssignment>();
    public ICollection<Review> Review { get; set; } = new List<Review>();
}

public enum MentorStatus {
    Active,
    Inactive
}