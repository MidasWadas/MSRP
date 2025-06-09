using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MSRP.Infrastructure.Persistence;

namespace MSRP.DbMigrator.Services;

public class DatabaseMigrationService(ApiContext context, IConfiguration configuration)
{
    public async Task MigrateAsync()
    {
        Console.WriteLine("Applying migrations to database...");

        if (configuration.GetValue<bool>("MigrationSettings:ForceRecreate"))
        {
            Console.WriteLine("Recreating database...");
            await context.Database.EnsureDeletedAsync();
        }
        
        // Apply migrations
        await context.Database.MigrateAsync();
        Console.WriteLine("Migrations successfully applied");
    }
}