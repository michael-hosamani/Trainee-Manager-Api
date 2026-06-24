// Trainee Response which excludes certain fields from the main Trainee Class
using TraineeManagementApi.Models;

namespace TraineeManagementApi.Dto;
public class TraineeResponse
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string TechStack { get; set; }
    public required Status Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}