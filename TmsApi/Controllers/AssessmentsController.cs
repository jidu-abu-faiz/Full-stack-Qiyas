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
        _logger.LogInformation("Assessment results requested.");

        var enrollments = _enrollmentService.GetAllAsync().Result;

        _auditService.Record("Assessment results accessed.");
        
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
    private readonly IAuditService _auditService;

    private readonly IEnrollmentService _enrollmentService;
    private readonly ILogger<AssessmentsController> _logger;

    public AssessmentsController(
        IAuditService auditService,
        IEnrollmentService enrollmentService,
        ILogger<AssessmentsController> logger)
    {
        _auditService = auditService;
        _enrollmentService = enrollmentService;
        _logger = logger;
    }
}


