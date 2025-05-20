using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MSRP.Infrastructure.Persistence;
using MSRP.DbMigrator.Services;

namespace MSRP.DbMigrator;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        if (args.Contains("--help"))
        {
            Console.WriteLine("MSRP Database Migrator");
            Console.WriteLine("Commands:");
            Console.WriteLine("  --skip-seed         Skip database seeding");
            Console.WriteLine("  --recreate          Recreate the database (caution!)");
            Console.WriteLine("  --help              Display this help");
            return 0;
        }
        
        Console.WriteLine("Starting database migrator...");

        try
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddInMemoryCollection(new Dictionary<string, string?>
                {
                    {"MigrationSettings:SkipSeeding", args.Contains("--skip-seed").ToString()},
                    {"MigrationSettings:ForceRecreate", args.Contains("--recreate").ToString()}
                })
                .Build();

            var services = new ServiceCollection();

            // Register DbContext
            services.AddDbContext<ApiContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            // Register services
            services.AddTransient<DatabaseMigrationService>();
            services.AddTransient<DatabaseSeeder>();
            services.AddSingleton<IConfiguration>(configuration);

            var serviceProvider = services.BuildServiceProvider();

            // Run migrations
            using var scope = serviceProvider.CreateScope();
            var migrationService = scope.ServiceProvider.GetRequiredService<DatabaseMigrationService>();
            var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();

            await migrationService.MigrateAsync();

            if (!configuration.GetValue<bool>("MigrationSettings:SkipSeeding"))
            {
                await seeder.SeedAsync();
            }

            Console.WriteLine("Migration completed successfully!");
            return 0;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Migration failed: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
            Console.ResetColor();
            return 1;
        }
    }
}