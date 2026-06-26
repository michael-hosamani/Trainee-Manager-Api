using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Dto;

namespace TraineeDirectory.Api.Controllers;

[ApiController]
[Route("api/trainees")]
public class TraineeController: ControllerBase
{
    // GET /api/trainees route
    [HttpGet]
    public ActionResult Get(){
        DummyTrainee trainee = new()
        {
            Name = "john",
            Mentor = "michael",
            TechStack = "dotnet",
            CreatedDate = DateTime.Now  
        };

        return Ok(trainee);
    }

    // GET /api/trainees/{correlationId} route
    [HttpGet("{correlationId}")]
    public ActionResult GetById(Guid correlationId){

        DummyTrainee trainee = new()
        {
            Name = "john",
            Mentor = "michael",
            TechStack = "dotnet",
            CreatedDate = DateTime.Now,
        };

        TestResponseDto res = new()
        {
            Trainee = trainee,
            CorrelationId = correlationId
        };

        return Ok(res);
    }

}