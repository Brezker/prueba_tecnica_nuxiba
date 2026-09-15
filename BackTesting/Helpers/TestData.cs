using TestBackNuxiba.Data;
using TestBackNuxiba.Models;

namespace BackTesting.Helpers;

public static class TestData
{
    public static async Task<User> AddUserAsync(CCenterDbContext context, int userId = 1)
    {
        var user = new User
        {
            User_id = userId,
            Login = $"test.user{userId}",
            Nombres = "Test",
            ApellidoPaterno = "User",
            Status = 1,
            fCreate = new DateTime(2026, 1, 1, 8, 0, 0)
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return user;
    }

    public static async Task<Login> AddMovementAsync(
        CCenterDbContext context,
        int userId,
        int tipoMov,
        DateTime fecha)
    {
        var login = new Login
        {
            User_id = userId,
            Extension = 1001,
            TipoMov = tipoMov,
            fecha = fecha
        };

        context.Logins.Add(login);
        await context.SaveChangesAsync();

        return login;
    }
}
