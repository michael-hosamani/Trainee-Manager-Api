using Microsoft.AspNetCore.Mvc;
using TraineeManagementApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using TraineeManagementApi.Models;
using TraineeManagementApi.Services;
using TraineeManagementApi.Dto;

namespace TraineeManagementApi.Controllers;

// [Authorize(Roles = $"{nameof(Role.Mentor)}, {nameof(Role.Trainee)}")]
[ApiController]
[Route("api/submissions")]
public class SubmissionsController: ControllerBase 
{
    private readonly ISubmissionService _service;

    public SubmissionsController(ISubmissionService service)
    {
        _service = service;
    }

    // GET /api/submissions
    /// <summary>
    /// Retrieves all the Submission.
    /// </summary>
    /// <returns>All the Submission.</returns>
    /// <response code="200">Returns all the Submission.</response>
    [HttpGet]
    public async Task<ActionResult> GetAllSubmissions()
    {
        var submissionData = await _service.GetAllSubmissions();
        return Ok(submissionData);
    }

    // GET /api/submissions/{id}
    /// <summary>
    /// Retrieves a specific Submission by ID.
    /// </summary>
    /// <param name="id">The ID of the Submission to retrieve.</param>
    /// <returns>The requested Submission.</returns>
    /// <response code="200">Returns the requested Submission.</response>
    /// <response code="404">If the Submission is not found.</response>
    [HttpGet("{id}")]
    public async Task<ActionResult> GetSubmissionById(int id)
    {
        Submission? submission = await _service.GetSubmissionById(id);
        if(submission == null)
        {
            return NotFound(new { message = "Submission not found" });
        }

        return Ok(submission);
    }   

    // POST /api/submissions
    /// <summary>
    /// Creates a new Submission.
    /// </summary>
    /// <param name="submission">Submission details required for creation</param>
    /// <returns>The newly created Submission.</returns>
    /// <response code="200">Returns the newly created Submission.</response>
    [HttpPost]
    public async Task<ActionResult> CreateSubmission(CreateSubmissionRequest submission)
    {
        SubmissionResponse submissionResponse = await _service.CreateSubmission(submission);

        return Ok(submissionResponse);
    }

    // POST /api/submissions/{submissionId}/files
    /// <summary>
    /// Uploads a file
    /// </summary>
    /// <param name="submissionId">SubmissionId required to upload file</param>
    /// <returns>The newly generated path for the file uploaded.</returns>
    /// <response code="200">Returns the newly generated path for the file uploaded.</response>
    [HttpPost("{submissionId}/files")]
    public async Task<ActionResult> UploadFile(int submissionId, CreateSubmissionFileRequest createSubmissionFileRequest, CancellationToken cancellationToken)
    {
        string res = await _service.UploadFile(submissionId, createSubmissionFileRequest, cancellationToken);
        return Ok(res);
    }

    // GET /api/submissions/{id}/summary
    /// <summary>
    /// Retrieves a specific Submission summary by ID.
    /// </summary>
    /// <param name="id">The ID of the Submission summary to retrieve.</param>
    /// <returns>The requested Submission.</returns>
    /// <response code="200">Returns the requested Submission summary.</response>
    /// <response code="404">If the Submission summary is not found.</response>
    [HttpGet("{id}/summary")]
    public async Task<ActionResult> GetSummary(int id, CancellationToken cancellationToken)
    {
        Submission? submission = await _service.GetSubmissionSummaryById(id, cancellationToken);
        if(submission == null)
        {
            return NotFound(new { message = "Submission not found" });
        }

        return Ok(submission);
    }
}