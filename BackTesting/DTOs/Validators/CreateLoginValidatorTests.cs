using System.ComponentModel.DataAnnotations;
using TestBackNuxiba.DTOs;

namespace BackTesting.DTOs.Validators;

// Runs the same DataAnnotations validation that [ApiController] runs before reaching the action.
public class CreateLoginValidatorTests
{
    private static List<ValidationResult> Validate(object model)
    {
        var results = new List<ValidationResult>();

        Validator.TryValidateObject(
            model,
            new ValidationContext(model),
            results,
            validateAllProperties: true);

        return results;
    }

    private static UpdateLoginDto CreateDto(DateTime fecha) => new()
    {
        User_id = 1,
        Extension = 1001,
        TipoMov = 1,
        fecha = fecha
    };

    [Test]
    public void Fecha_InThePast_IsValid()
    {
        var results = Validate(CreateDto(DateTime.Now.AddHours(-1)));

        Assert.That(results, Is.Empty);
    }

    [Test]
    public void Fecha_InTheFuture_IsInvalid()
    {
        var results = Validate(CreateDto(DateTime.Now.AddDays(1)));

        Assert.That(results.Select(r => r.ErrorMessage), Has.One.Contains("futuro"));
    }

    [Test]
    public void Fecha_Before2000_IsInvalid()
    {
        var results = Validate(CreateDto(new DateTime(1999, 12, 31)));

        Assert.That(results, Has.Count.EqualTo(1));
    }

    [Test]
    public void Fecha_NotSent_IsInvalid()
    {
        // A DateTime that is not sent in the JSON arrives as 0001-01-01; [Required] alone does not catch it.
        var results = Validate(CreateDto(default));

        Assert.That(results, Has.Count.EqualTo(1));
    }
}
