using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSRP.Domain.Entities.Recipe;
using MSRP.Domain.Entities.Recipe.ValueObjects;

namespace MSRP.Infrastructure.Persistence.Configuration;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.Property(p => p.Ingredients)
            .HasConversion(
                v => string.Join(';', v),
                v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());

        builder.Property(p => p.Instructions)
            .HasConversion(
                v => string.Join(';', v),
                v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());

        builder.Property(p => p.Difficulty)
            .HasColumnType("jsonb")
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<RecipeDifficulty>(v, (JsonSerializerOptions)null));

        builder.Property(p => p.CuisineType)
            .HasColumnType("jsonb")
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<RecipeCuisineType>(v, (JsonSerializerOptions)null));

        builder.Property(p => p.MealType)
            .HasColumnType("jsonb")
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<RecipeMealType>(v, (JsonSerializerOptions)null));

        builder.Property(p => p.Dietaries)
            .HasColumnType("jsonb")
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<List<RecipeDietaryOption>>(v, (JsonSerializerOptions)null));
    }
}