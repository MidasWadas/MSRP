using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSRP.Domain.Recipe;

namespace MSRP.Infrastructure.Persistence.Configuration;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.Property(p => p.DietariesIds)
            .HasConversion(
                v => JsonSerializer.Serialize(v ?? new List<int>(), (JsonSerializerOptions?)null),
                v => string.IsNullOrEmpty(v)
                    ? new List<int>()
                    : JsonSerializer.Deserialize<List<int>>(v, (JsonSerializerOptions?)null) ?? new List<int>())
            .HasColumnType("jsonb")
            .IsRequired();

        
        builder.Property(p => p.Ingredients)
            .HasConversion(
                v => string.Join(';', v),
                v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());

        builder.Property(p => p.Instructions)
            .HasConversion(
                v => string.Join(';', v),
                v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());
    }
}