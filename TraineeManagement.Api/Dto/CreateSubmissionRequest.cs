
using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Models;

namespace TraineeManagement.Api.Dto;

public class CreateSubmissionRequest
{
    [Required(ErrorMessage = "TaskAssignmentId is required")]
    public int TaskAssignmentId { get; set; }

    [Required(ErrorMessage = "SubmissionUrl is required")]
    public required string SubmissionUrl { get; set; }

    [Required(ErrorMessage = "Notes is required")]
    public required string Notes { get; set; }

    [Required(ErrorMessage = "SubmissionDate is required")]
    public DateTime SubmissionDate { get; set; }

    [Required(ErrorMessage = "Status is required")]
    [EnumDataType(typeof(SubmissionStatus), ErrorMessage = "Status must be valid")]
    public SubmissionStatus Status { get; set; }
}
