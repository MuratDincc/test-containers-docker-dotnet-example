using Customer.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Customer.Api.Extensions;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<CustomerApiContext>();

        dbContext.Database.Migrate();
    }
}
