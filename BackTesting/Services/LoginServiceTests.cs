using BackTesting.Helpers;
using Microsoft.EntityFrameworkCore;
using TestBackNuxiba.Data;
using TestBackNuxiba.DTOs;
using TestBackNuxiba.Exceptions;
using TestBackNuxiba.Services;

namespace BackTesting.Services;

public class LoginServiceTests
{
    private const int Login = 1;
    private const int Logout = 0;

    private CCenterDbContext _context = null!;
    private LoginService _service = null!;

    [SetUp]
    public void SetUp()
    {
        _context = TestDbContextFactory.Create();
        _service = new LoginService(_context);
    }

    [TearDown]
    public void TearDown() => _context.Dispose();

    // ---------- CreateAsync ----------

    [Test]
    public void CreateAsync_UserDoesNotExist_ThrowsNotFound()
    {
        var dto = new CreateLoginDto { User_id = 999, Extension = 1001, TipoMov = Login };

        var ex = Assert.ThrowsAsync<NotFoundException>(() => _service.CreateAsync(dto));

        Assert.That(ex!.Message, Does.Contain("999"));
    }

    [Test]
    public async Task CreateAsync_FirstLogin_SavesMovementWithServerDate()
    {
        await TestData.AddUserAsync(_context);
        var before = DateTime.Now;

        var result = await _service.CreateAsync(
            new CreateLoginDto { User_id = 1, Extension = 1001, TipoMov = Login });

        Assert.Multiple(() =>
        {
            Assert.That(result.fecha, Is.InRange(before, DateTime.Now));
            Assert.That(_context.Logins.Count(), Is.EqualTo(1));
        });
    }

    [Test]
    public async Task CreateAsync_LoginWithoutPreviousLogout_ThrowsBusinessRule()
    {
        await TestData.AddUserAsync(_context);
        await _service.CreateAsync(new CreateLoginDto { User_id = 1, Extension = 1001, TipoMov = Login });

        var ex = Assert.ThrowsAsync<BusinessRuleException>(() =>
            _service.CreateAsync(new CreateLoginDto { User_id = 1, Extension = 1001, TipoMov = Login }));

        Assert.That(ex!.Message, Does.Contain("login without a previous logout"));
    }

    [Test]
    public async Task CreateAsync_FirstMovementIsLogout_ThrowsBusinessRule()
    {
        await TestData.AddUserAsync(_context);

        Assert.ThrowsAsync<BusinessRuleException>(() =>
            _service.CreateAsync(new CreateLoginDto { User_id = 1, Extension = 1001, TipoMov = Logout }));
    }

    // ---------- UpdateAsync ----------

    [Test]
    public void UpdateAsync_LoginRecordDoesNotExist_ThrowsNotFound()
    {
        var dto = new UpdateLoginDto { User_id = 1, Extension = 1001, TipoMov = Login, fecha = DateTime.Now };

        Assert.ThrowsAsync<NotFoundException>(() => _service.UpdateAsync(12345, dto));
    }

    [Test]
    public async Task UpdateAsync_ChangeBreaksLoginLogoutSequence_ThrowsBusinessRule()
    {
        await TestData.AddUserAsync(_context);
        await TestData.AddMovementAsync(_context, 1, Login, new DateTime(2026, 1, 5, 8, 0, 0));
        var logout = await TestData.AddMovementAsync(_context, 1, Logout, new DateTime(2026, 1, 5, 17, 0, 0));

        // Turning the logout into a login leaves login -> login
        var dto = new UpdateLoginDto { User_id = 1, Extension = 1001, TipoMov = Login, fecha = logout.fecha };

        Assert.ThrowsAsync<BusinessRuleException>(() => _service.UpdateAsync(logout.LogLoginId, dto));
    }

    [Test]
    public async Task UpdateAsync_ValidChange_UpdatesRecord()
    {
        await TestData.AddUserAsync(_context);
        await TestData.AddMovementAsync(_context, 1, Login, new DateTime(2026, 1, 5, 8, 0, 0));
        var logout = await TestData.AddMovementAsync(_context, 1, Logout, new DateTime(2026, 1, 5, 17, 0, 0));
        var newDate = new DateTime(2026, 1, 5, 18, 30, 0);

        var dto = new UpdateLoginDto { User_id = 1, Extension = 2002, TipoMov = Logout, fecha = newDate };

        var result = await _service.UpdateAsync(logout.LogLoginId, dto);

        Assert.Multiple(() =>
        {
            Assert.That(result.fecha, Is.EqualTo(newDate));
            Assert.That(result.Extension, Is.EqualTo(2002));
        });
    }

    // ---------- DeleteAsync ----------

    [Test]
    public void DeleteAsync_LoginRecordDoesNotExist_ThrowsNotFound()
    {
        Assert.ThrowsAsync<NotFoundException>(() => _service.DeleteAsync(12345));
    }

    [Test]
    public async Task DeleteAsync_ExistingRecord_RemovesIt()
    {
        await TestData.AddUserAsync(_context);
        var login = await TestData.AddMovementAsync(_context, 1, Login, new DateTime(2026, 1, 5, 8, 0, 0));

        await _service.DeleteAsync(login.LogLoginId);

        Assert.That(await _context.Logins.AnyAsync(), Is.False);
    }
}
