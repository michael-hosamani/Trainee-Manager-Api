using TraineeManagementApi.Models;
using System.ComponentModel.DataAnnotations;

namespace TraineeManagementApi.Dto;

public class UpdateTaskAssignmentRequest
{
    public TaskAssignmentStatus? Status { get; set; }
}