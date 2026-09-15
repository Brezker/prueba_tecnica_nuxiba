using Microsoft.EntityFrameworkCore;
using TestBackNuxiba.Data;

namespace BackTesting.Helpers;

public static class TestDbContextFactory
{
    // Each call returns a context backed by a new, isolated in-memory database,
    // so tests never share data. Note: InMemory does not enforce FKs or check constraints.
    public static CCenterDbContext Create()
    {
        var options = new DbContextOptionsBuilder<CCenterDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new CCenterDbContext(options);
    }
}
