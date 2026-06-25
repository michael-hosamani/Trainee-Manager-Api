using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using TraineeManagement.Api.Services;

namespace TraineeManagement.Api.Controllers;

[ApiController]
[Route("api/processing-jobs")]
public class ProcessingJobController: ControllerBase
{
    private readonly IProcessingJobService _service;

    public ProcessingJobController(IProcessingJobService service)
    {
        _service = service;
    }

    // GET /api/processing-jobs/{id} route
    /// <summary>
    /// Retrieves a specific ProcessingJob by ID.
    /// </summary>
    /// <param name="id">The ID of the ProcessingJob to retrieve.</param>
    /// <returns>The requested ProcessingJob.</returns>
    /// <response code="200">Returns the requested ProcessingJob.</response>
    /// <response code="404">If the ProcessingJob is not found.</response>
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id){
        ProcessingJob? processingJob = await _service.GetById(id);
        if(processingJob == null)
        {
            return NotFound("Processing Job not found");
        }

        return Ok(processingJob);
    }

}