using Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace TraineeManagement.Api.Dto;

public class UpdateTaskAssignmentRequest
{
    public TaskAssignmentStatus? Status { get; set; }
}