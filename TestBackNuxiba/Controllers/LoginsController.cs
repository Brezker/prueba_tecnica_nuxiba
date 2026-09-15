using Microsoft.AspNetCore.Mvc;
using TestBackNuxiba.DTOs;
using TestBackNuxiba.Models;
using TestBackNuxiba.Services;

namespace TestBackNuxiba.Controllers;

// Errors are not handled here: the service throws NotFoundException / BusinessRuleException
// and GlobalExceptionHandler turns them into ProblemDetails responses.
[ApiController]
[Route("logins")]
[Produces("application/json")]
public class LoginsController : ControllerBase
{
    private readonly ILoginService _loginService;
    private readonly IReportService _reportService;

    public LoginsController(ILoginService loginService, IReportService reportService)
    {
        _loginService = loginService;
        _reportService = reportService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Login>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var logins = await _loginService.GetAllAsync();

        return Ok(logins);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Login), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create(CreateLoginDto dto)
    {
        var login = await _loginService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetAll),
            null,
            login);
    }

    [HttpPut("{id:long}")]
    [ProducesResponseType(typeof(Login), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
    long id,
    UpdateLoginDto dto)
    {
        var login = await _loginService.UpdateAsync(id, dto);

        return Ok(login);
    }

    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(long id)
    {
        await _loginService.DeleteAsync(id);

        return NoContent();
    }

    [HttpGet("report")]
    [Produces("text/csv")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GenerateReport()
    {
        var csv = await _reportService.GenerateLoginReportAsync();

        return File(
            csv,
            "text/csv",
            "login-report.csv");
    }
}
