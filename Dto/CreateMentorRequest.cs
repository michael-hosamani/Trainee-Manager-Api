using TraineeManagementApi.Models;
using System.ComponentModel.DataAnnotations;

namespace TraineeManagementApi.Dto;

public class CreateMentorRequest
{
    [Required(ErrorMessage = "First name is required")]
    [MaxLength(50, ErrorMessage = "First name should not exceed 50 charachters")]
    public required String FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [MaxLength(50, ErrorMessage = "Last name should not exceed 50 charachters")]
    public required String LastName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Valid email is required")]
    public required String Email { get; set; }

    [Required(ErrorMessage = "Expertise is required")]
    public required String  Expertise { get; set; }
    
    [Required(ErrorMessage = "Status is required")]
    [EnumDataType(typeof(MentorStatus), ErrorMessage = "Status must be valid")]
    public required MentorStatus Status { get; set; }
}