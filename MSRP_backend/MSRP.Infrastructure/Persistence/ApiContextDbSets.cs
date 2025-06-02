using Microsoft.EntityFrameworkCore;
using MSRP.Domain.Cuisine;
using MSRP.Domain.Dietary;
using MSRP.Domain.Difficulty;
using MSRP.Domain.MealType;
using MSRP.Domain.Recipe;

namespace MSRP.Infrastructure.Persistence;

public partial class ApiContext
{
    public DbSet<Recipe> Recepies { get; set; }
    public DbSet<Cuisine> CuisineOptions { get; set; }
    public DbSet<MealType> MealTypes { get; set; }
    public DbSet<Dietary> DietaryOptions { get; set; }
    public DbSet<Difficulty> DifficultyOptions { get; set; }
}