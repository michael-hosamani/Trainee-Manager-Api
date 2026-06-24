using Microsoft.AspNetCore.Mvc;
using TraineeManagementApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using TraineeManagementApi.Models;
using TraineeManagementApi.Services;
using TraineeManagementApi.Dto;

namespace TraineeManagementApi.Controllers;

[Authorize(Roles = nameof(Role.Admin))]
[ApiController]
[Route("api/learning-tasks")]
public class LearningTaskController: ControllerBase 
{
    private ILearningTaskService _service;

    public LearningTaskController(ILearningTaskService service)
    {
        _service = service;
    }

    // GET /api/learning-tasks
    /// <summary>
    /// Retrieves all the LearningTasks.
    /// </summary>
    /// <returns>All the LearningTasks.</returns>
    /// <response code="200">Returns all the LearningTasks.</response>
    [HttpGet]
    public async Task<ActionResult> GetAllLearningTasks()
    { 
        var learningTaskData = await _service.GetAllLearningTasks();
        return Ok(learningTaskData);
    }

    // GET /api/learning-tasks/{id}
    /// <summary>
    /// Retrieves a specific LearningTasks by ID.
    /// </summary>
    /// <param name="id">The ID of the LearningTasks to retrieve.</param>
    /// <returns>The requested LearningTasks.</returns>
    /// <response code="200">Returns the requested LearningTasks.</response>
    /// <response code="404">If the LearningTasks is not found.</response>
    [HttpGet("{id}")]
    public async Task<ActionResult> GetLearningTaskById(int id)
    {
        LearningTask? learningTask = await _service.GetLearningTaskById(id);
        if(learningTask == null)
        {
            return NotFound(new { message = "LearningTask not found" });
        }

        return Ok(learningTask);
    }   

    // POST /api/learning-tasks
    /// <summary>
    /// Creates a new LearningTask.
    /// </summary>
    /// <param name="learningTask">LearningTask details required for creation</param>
    /// <returns>The newly created LearningTask.</returns>
    /// <response code="200">Returns the newly created LearningTask.</response>
    [HttpPost]
    public async Task<ActionResult> CreateLearningTask(CreateLearningTaskRequest learningTask)
    {
        LearningTaskResponse learningTaskResponse = await _service.CreateLearningTask(learningTask);

        return Ok(learningTaskResponse);
    }

    // PUT /api/learning-tasks/{id}
      /// <summary>
    /// Update a specific LearningTask by ID.
    /// </summary>
    /// <param name="id">The ID of the LearningTask to retrieve.</param>
    /// <returns>The updated LearningTask.</returns>
    /// <response code="200">Returns the updated LearningTask.</response>
    /// <response code="404">If the LearningTask is not found.</response>
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateLearningTaskDetails(int id, UpdateLearningTaskRequest learningTask)
    {
        LearningTask? updatedLearningTaskDetails = await _service.UpdateLearningTaskDetails(id, learningTask);

        if(updatedLearningTaskDetails == null)
        {
            return NotFound(new { message = "Invalid LearningTask Id" });
        }

        return Ok(updatedLearningTaskDetails);
    }

    // DELETE /api/learning-tasks/{id}
    /// <summary>
    /// Delete a specific LearningTask by ID.
    /// </summary>
    /// <param name="id">The ID of the LearningTask to retrieve.</param>
    /// <returns>The deleted LearningTask.</returns>
    /// <response code="200">Returns the deleted LearningTask.</response>
    /// <response code="404">If the LearningTask is not found.</response>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteLearningTask(int id)
    {
        bool isLearningTaskDeleted = await _service.DeleteLearningTaskDetails(id);
        if (isLearningTaskDeleted == false)
        {
            return NotFound(new { message = "Invalid LearningTask Data"});
        }
        return NoContent();
    }
}