using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using TestBackNuxiba.Exceptions;
using TestBackNuxiba.Handlers;

namespace BackTesting.Handlers;

public class GlobalExceptionHandlerTests
{
    private GlobalExceptionHandler _handler = null!;

    [SetUp]
    public void SetUp()
    {
        _handler = new GlobalExceptionHandler(NullLogger<GlobalExceptionHandler>.Instance);
    }

    private static DefaultHttpContext CreateHttpContext()
    {
        var context = new DefaultHttpContext();
        context.Request.Method = "POST";
        context.Request.Path = "/logins";
        context.Response.Body = new MemoryStream();
        return context;
    }

    private static async Task<ProblemDetails> ReadProblemAsync(HttpContext context)
    {
        context.Response.Body.Seek(0, SeekOrigin.Begin);

        var problem = await JsonSerializer.DeserializeAsync<ProblemDetails>(
            context.Response.Body,
            new JsonSerializerOptions(JsonSerializerDefaults.Web));

        return problem!;
    }

    private static IEnumerable<TestCaseData> DomainExceptions()
    {
        yield return new TestCaseData(
                new NotFoundException("User with id 999 does not exist."),
                StatusCodes.Status404NotFound)
            .SetName("TryHandleAsync_NotFoundException_Returns404WithMessage");

        yield return new TestCaseData(
                new BusinessRuleException("The user cannot register a login without a previous logout."),
                StatusCodes.Status400BadRequest)
            .SetName("TryHandleAsync_BusinessRuleException_Returns400WithMessage");
    }

    [TestCaseSource(nameof(DomainExceptions))]
    public async Task TryHandleAsync_DomainException_ReturnsProblemDetailsWithMessage(
        Exception exception,
        int expectedStatus)
    {
        var context = CreateHttpContext();

        var handled = await _handler.TryHandleAsync(context, exception, CancellationToken.None);
        var problem = await ReadProblemAsync(context);

        Assert.Multiple(() =>
        {
            Assert.That(handled, Is.True);
            Assert.That(context.Response.StatusCode, Is.EqualTo(expectedStatus));
            Assert.That(context.Response.ContentType, Does.StartWith("application/problem+json"));
            Assert.That(problem.Status, Is.EqualTo(expectedStatus));
            Assert.That(problem.Detail, Is.EqualTo(exception.Message));
            Assert.That(problem.Instance, Is.EqualTo("/logins"));
        });
    }

    [Test]
    public async Task TryHandleAsync_DbUpdateException_Returns409WithGenericMessage()
    {
        var context = CreateHttpContext();
        var exception = new DbUpdateException("The INSERT statement conflicted with the FOREIGN KEY constraint.");

        await _handler.TryHandleAsync(context, exception, CancellationToken.None);
        var problem = await ReadProblemAsync(context);

        Assert.Multiple(() =>
        {
            Assert.That(context.Response.StatusCode, Is.EqualTo(StatusCodes.Status409Conflict));
            Assert.That(problem.Detail, Does.Not.Contain("FOREIGN KEY"));
        });
    }

    [Test]
    public async Task TryHandleAsync_UnexpectedException_Returns500WithoutLeakingDetails()
    {
        var context = CreateHttpContext();
        var exception = new Exception("Login failed. Server=localhost,1435;Password=YourStrong!Passw0rd");

        await _handler.TryHandleAsync(context, exception, CancellationToken.None);
        var problem = await ReadProblemAsync(context);

        Assert.Multiple(() =>
        {
            Assert.That(context.Response.StatusCode, Is.EqualTo(StatusCodes.Status500InternalServerError));
            Assert.That(problem.Detail, Is.EqualTo("An unexpected error occurred."));
            Assert.That(problem.Detail, Does.Not.Contain("Password"));
            Assert.That(problem.Extensions.ContainsKey("traceId"), Is.True);
        });
    }
}
