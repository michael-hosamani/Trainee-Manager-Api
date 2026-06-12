using System.Data.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TraineeManagementApi.Models;
using TraineeManagementApi.Dto;
using System.Net;

namespace TraineeManagementApi.Services;

public class TaskAssignmentService: ITaskAssignmentService 
{
    private readonly AppDbContext _db;
    private readonly ILogger<TraineeService> _logger;

    public TaskAssignmentService(AppDbContext db, ILogger<TraineeService> logger){
        _db = db;
        _logger = logger;
    }

    // This function returns the list of all the TaskAssignments
    public async Task<List<TaskAssignment>> GetAllTaskAssignments()
    {
        return await _db.TaskAssignments.ToListAsync();
    }

    // This function fetches a TaskAssignment based on its Id
    public async Task<TaskAssignment?> GetTaskAssignmentById(int id)
    {
        var result = await _db.TaskAssignments.SingleOrDefaultAsync(t => t.Id == id);
        if(result != null)
        {
            _logger.LogError("TaskAssignment not found");
            return result;
        }

        return null;
    }

    // This funciton creates a new TaskAssignment 
    public async Task<TaskAssignmentResponse?> CreateTaskAssignment(CreateTaskAssignmentRequest taskAssignment)
    {   
        Trainee? findTrainee = await _db.Trainees.SingleOrDefaultAsync(t => t.Id == taskAssignment.TraineeId);
        if(findTrainee == null)
        {
            _logger.LogError("Trainee not found");
            return null;
        }

        Mentor? findMentor = await _db.Mentors.SingleOrDefaultAsync(t => t.Id == taskAssignment.MentorId);
        if(findMentor == null)
        {
            _logger.LogError("Mentor not found");
            return null;
        }

        LearningTask? findLearningTask = await _db.LearningTasks.SingleOrDefaultAsync(t => t.Id == taskAssignment.LearningTaskId);
        if(findLearningTask == null)
        {
            _logger.LogError("Learning task not found");
            return null;
        }

        if(taskAssignment.DueDate < taskAssignment.AssignedDate)
        {
            return null;
        }

        TaskAssignment newTaskAssignment = new TaskAssignment
        {
            TraineeId = taskAssignment.TraineeId,
            MentorId = taskAssignment.MentorId,
            LearningTaskId = taskAssignment.LearningTaskId,
            Status = taskAssignment.Status,
            AssignedDate = taskAssignment.AssignedDate,
            DueDate = taskAssignment.DueDate,
        };

        await _db.TaskAssignments.AddAsync(newTaskAssignment);
        await _db.SaveChangesAsync();

        TaskAssignmentResponse TaskAssignmentResponse = new TaskAssignmentResponse
        {   
            TraineeId = newTaskAssignment.TraineeId,
            MentorId = newTaskAssignment.MentorId,
            LearningTaskId = newTaskAssignment.LearningTaskId,
            Status = newTaskAssignment.Status,
            AssignedDate = newTaskAssignment.AssignedDate,
            DueDate = newTaskAssignment.DueDate,
        };
        _logger.LogInformation("New TaskAssignment created successfully");
        return TaskAssignmentResponse;
    }

    // This function fetches the TaskAssignment based on its Id and updates certain fields entered through the body
    public async Task<TaskAssignment?> UpdateTaskAssignmentDetails(int id, TaskAssignmentStatus? status)
    {
        var findTaskAssignment = await _db.TaskAssignments.SingleOrDefaultAsync(t => t.Id == id);
        if(findTaskAssignment == null)
        {
            _logger.LogError("TaskAssignment not found");
            return null;
        }

        // if(taskAssignment.TraineeId.HasValue)
        //     findTaskAssignment.TraineeId = taskAssignment.TraineeId.Value;
        
        // if(taskAssignment.MentorId.HasValue)
        //     findTaskAssignment.MentorId = taskAssignment.MentorId.Value;

        // if(taskAssignment.LearningTaskId.HasValue)
        //     findTaskAssignment.LearningTaskId = taskAssignment.LearningTaskId.Value;

        // if(taskAssignment.AssignedDate.HasValue)
        //     findTaskAssignment.AssignedDate = taskAssignment.AssignedDate.Value;

        if(status.HasValue)
            findTaskAssignment.Status = status.Value;

        await _db.SaveChangesAsync();

        _logger.LogInformation("TaskAssignment updated successfully");

        return findTaskAssignment;
    }
}