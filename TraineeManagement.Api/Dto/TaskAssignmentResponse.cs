using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shared.Models;

namespace TraineeManagement.Api.Dto;

public class TaskAssignmentResponse
{
    public required int TraineeId { get; set; }
    public required int MentorId { get; set; }
    public required int LearningTaskId { get; set; }
    public required DateTime AssignedDate { get; set; }
    public required DateTime DueDate { get; set; }
    public required TaskAssignmentStatus Status { get; set; }
    public string? Remarks { get; set; }
}