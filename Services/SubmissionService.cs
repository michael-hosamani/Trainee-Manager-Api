using System.Data.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TraineeManagementApi.Models;
using TraineeManagementApi.Dto;
using TraineeManagementApi.Services;

namespace TraineeManagementApi.Services;

public class SubmissionService: ISubmissionService 
{
    private readonly AppDbContext _db;
    private readonly ILogger<TraineeService> _logger;

    public SubmissionService(AppDbContext db, ILogger<TraineeService> logger){
        _db = db;
        _logger = logger;
    }

    // This function returns the list of all the Submissions
    public async Task<List<Submission>> GetAllSubmissions()
    {
        return await _db.Submissions.ToListAsync();
    }

    // This function fetches a Submission based on its Id
    public async Task<Submission?> GetSubmissionById(int id)
    {
        var result = await _db.Submissions.SingleOrDefaultAsync(t => t.Id == id);
        if(result != null)
        {
            _logger.LogError("Submission not found");
            return result;
        }

        return null;
    }

    // This funciton creates a new Submission
    public async Task<SubmissionResponse> CreateSubmission(CreateSubmissionRequest submission)
    {
        Submission newSubmission = new Submission
        {
            TaskAssignmentId = submission.TaskAssignmentId,
            SubmissionUrl = submission.SubmissionUrl,
            Notes = submission.Notes,
            Status = submission.Status,
            SubmissionDate = submission.SubmissionDate
        };

        await _db.Submissions.AddAsync(newSubmission);
        await _db.SaveChangesAsync();

        SubmissionResponse submissionResponse = new SubmissionResponse
        {   
            Id = newSubmission.Id,
            TaskAssignmentId = newSubmission.TaskAssignmentId,
            SubmissionUrl = newSubmission.SubmissionUrl,
            Notes = newSubmission.Notes,
            Status = newSubmission.Status,
            SubmissionDate = newSubmission.SubmissionDate
        };
        _logger.LogInformation("New Submission created successfully");
        return submissionResponse;
    }
}