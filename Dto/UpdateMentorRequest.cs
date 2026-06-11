using TraineeManagementApi.Models;
using System.ComponentModel.DataAnnotations;

namespace TraineeManagementApi.Dto;
// Dto for validating inputs of update trainee request
public class UpdateMentorRequest
{
    [MaxLength(50, ErrorMessage = "First name should not exceed 50 charachters")]
    public string? FirstName { get; set; }

    [MaxLength(50, ErrorMessage = "Last name should not exceed 50 charachters")]
    public string? LastName { get; set; }

    [EmailAddress(ErrorMessage = "Valid email is required")]
    public string? Email { get; set; }

    public string? Expertise { get; set; }
    
    [EnumDataType(typeof(MentorStatus), ErrorMessage = "Status must be valid")]
    public MentorStatus? Status { get; set; }
}