using Microsoft.EntityFrameworkCore;
using MSRP.Domain.Entities.CuisineOption;
using MSRP.Domain.Entities.DietaryOption;
using MSRP.Domain.Entities.DifficultyOption;
using MSRP.Domain.Entities.MealType;
using MSRP.Domain.Entities.Recipe;

namespace MSRP.Infrastructure.Persistence;

public partial class ApiContext
{
    public DbSet<Recipe> Recepies { get; set; }
    public DbSet<CuisineOption> CuisineOptions { get; set; }
    public DbSet<MealType> MealTypeOptions { get; set; }
    public DbSet<DietaryOption> DietaryOptions { get; set; }
    public DbSet<DifficultyOption> DifficultyOptions { get; set; }
}