using Microsoft.EntityFrameworkCore;
using MSRP.Application.Interfaces.RecipeRepository;
using MSRP.Domain.Entities.Recipe;
using MSRP.Infrastructure.Persistence;

namespace MSRP.Infrastructure.Repositories
{
    public class RecipeRepository(ApiContext context) : IRecipeRepository
    {
        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            return await context.Recepies.ToListAsync();
        }

        public async Task<Recipe?> GetRecipeByIdAsync(int id)
        {
            return await context.Recepies.FindAsync(id);
        }

        public async Task<Recipe> AddAsync(Recipe recipe)
        {
            await context.Recepies.AddAsync(recipe);
            await context.SaveChangesAsync();
            return recipe;
        }

        public async Task UpdateAsync(Recipe recipe)
        {
            context.Recepies.Update(recipe);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var recipe = await context.Recepies.FindAsync(id);
            if (recipe != null)
            {
                context.Recepies.Remove(recipe);
                await context.SaveChangesAsync();
            }
        }
    }
}