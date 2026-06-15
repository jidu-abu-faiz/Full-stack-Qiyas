using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TmsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssessmentsController : ControllerBase
{
    [Authorize]
    [HttpGet("results")]
    public IActionResult GetResults()
    {
        return Ok(new
        {
            CourseCode = "CS-101",
            StudentId = "S-001",
            LetterGrade = "A"
        });
    }
    [HttpGet("boom")]
    public IActionResult Boom()
    {
        throw new InvalidOperationException("Simulated failure.");
    }
}

