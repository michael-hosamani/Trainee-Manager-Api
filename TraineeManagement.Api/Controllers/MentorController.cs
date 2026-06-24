using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Shared.Models;
using TraineeManagement.Api.Services;
using TraineeManagement.Api.Dto;

namespace TraineeManagement.Api.Controllers;

[Authorize(Roles = nameof(Role.Admin))]
[ApiController]
[Route("api/mentors")]
public class MentorsController: ControllerBase 
{
    private IMentorService _service;

    public MentorsController(IMentorService service)
    {
        _service = service;
    }

    // GET /api/mentors
    /// <summary>
    /// Retrieves all the Mentors.
    /// </summary>
    /// <returns>All the Mentors.</returns>
    /// <response code="200">Returns all the Mentors.</response>
    [HttpGet]
    public async Task<ActionResult> GetAllMentors()
    {
        var MentorData = await _service.GetAllMentors();
        return Ok(MentorData);
    }

    // GET /api/mentors/{id}
    /// <summary>
    /// Retrieves a specific Mentor by ID.
    /// </summary>
    /// <param name="id">The ID of the Mentor to retrieve.</param>
    /// <returns>The requested Mentor.</returns>
    /// <response code="200">Returns the requested Mentor.</response>
    /// <response code="404">If the Mentor is not found.</response>
    [HttpGet("{id}")]
    public async Task<ActionResult> GetMentorById(int id)
    {
        Mentor? Mentor = await _service.GetMentorById(id);
        if(Mentor == null)
        {
            return NotFound(new { message = "Mentor not found" });
        }

        return Ok(Mentor);
    }   

    // POST /api/mentors
    /// <summary>
    /// Creates a new Mentor.
    /// </summary>
    /// <param name="mentor">Mentor details required for creation</param>
    /// <returns>The newly created Mentor.</returns>
    /// <response code="200">Returns the newly created Mentor.</response>
    [HttpPost]
    public async Task<ActionResult> CreateMentor(CreateMentorRequest mentor)
    {
        MentorResponse MentorResponse = await _service.CreateMentor(mentor);

        return Ok(MentorResponse);
    }

    // PUT /api/mentors/{id}
    /// <summary>
    /// Update a specific Mentor by ID.
    /// </summary>
    /// <param name="id">The ID of the Mentor to retrieve.</param>
    /// <returns>The updated Mentor.</returns>
    /// <response code="200">Returns the updated Mentor.</response>
    /// <response code="404">If the Mentor is not found.</response>
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateMentorDetails(int id, UpdateMentorRequest Mentor)
    {
        Mentor? updatedMentorDetails = await _service.UpdateMentorDetails(id, Mentor);

        if(updatedMentorDetails == null)
        {
            return NotFound(new { message = "Invalid Mentor Id" });
        }

        return Ok(updatedMentorDetails);
    }

    // DELETE /api/mentors/{id}
    /// <summary>
    /// Delete a specific Mentor by ID.
    /// </summary>
    /// <param name="id">The ID of the Mentor to retrieve.</param>
    /// <returns>The deleted Mentor.</returns>
    /// <response code="200">Returns the deleted Mentor.</response>
    /// <response code="404">If the Mentor is not found.</response>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMentor(int id)
    {
        bool isMentorDeleted = await _service.DeleteMentorDetails(id);
        if (isMentorDeleted == false)
        {
            return NotFound(new { message = "Invalid Mentor Data"});
        }
        return NoContent();
    }
}