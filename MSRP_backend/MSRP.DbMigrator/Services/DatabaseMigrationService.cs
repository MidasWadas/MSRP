using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MSRP.Infrastructure.Persistence;

namespace MSRP.DbMigrator.Services;

public class DatabaseMigrationService(ApiContext context, IConfiguration configuration)
{
    private readonly ApiContext _context = context;
    private readonly IConfiguration _configuration = configuration;

    public async Task MigrateAsync()
    {
        Console.WriteLine("Applying migrations to database...");

        if (_configuration.GetValue<bool>("MigrationSettings:ForceRecreate"))
        {
            Console.WriteLine("Recreating database...");
            await _context.Database.EnsureDeletedAsync();
        }
        
        // Apply migrations
        await _context.Database.MigrateAsync();
        Console.WriteLine("Migrations successfully applied");
    }
}