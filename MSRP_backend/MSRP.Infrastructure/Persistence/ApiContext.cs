using Microsoft.EntityFrameworkCore;
using MSRP.Infrastructure.Persistence.Configuration;

namespace MSRP.Infrastructure.Persistence
{
	public partial class ApiContext(DbContextOptions<ApiContext> options) : DbContext(options)
	{
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.HasDefaultSchema("public");
			modelBuilder.ApplyConfiguration(new RecipeConfiguration());
		}
	}
}
