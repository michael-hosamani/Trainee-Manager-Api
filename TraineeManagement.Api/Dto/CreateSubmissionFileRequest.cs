using System.ComponentModel.DataAnnotations;

namespace TraineeManagement.Api.Dto;

public class CreateSubmissionFileRequest
{
    [Required]
    public required int UploadedByUser { get; set; }
    public required IFormFile File { get; set; }
}