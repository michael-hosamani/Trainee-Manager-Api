using Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace TraineeManagement.Api.Dto;

public class CreateMentorRequest
{
    [Required(ErrorMessage = "First name is required")]
    [MaxLength(50, ErrorMessage = "First name should not exceed 50 charachters")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [MaxLength(50, ErrorMessage = "Last name should not exceed 50 charachters")]
    public required string LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Valid email is required")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Expertise is required")]
    public required string  Expertise { get; set; }
    
    [Required(ErrorMessage = "Status is required")]
    [EnumDataType(typeof(MentorStatus), ErrorMessage = "Status must be valid")]
    public required MentorStatus Status { get; set; }
}