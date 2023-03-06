using Domain;

namespace Persistence
{
  public class Seed
  {
    public static async Task SeedData(DataContext context)
    {
      if (context.Categories == null ? false : !context.Categories.Any())
      {
        var categories = new List<Category>
        {
            new Category
            {
                Title = "Programming",
                Description = "All topics in Programming",
                IsActive = true,
                Notes = "Notes"
            },
            new Category
            {
                Title = "Aptitude",
                Description = "All topics in Aptitude",
                IsActive = true,
                Notes = "Notes"
            },
            new Category
            {
                Title = "Reasoning",
                Description = "All topics in Reasoning",
                IsActive = true,
                Notes = "Notes"
            },
            new Category
            {
                Title = "Vocabulary",
                Description = "All topics in Vocabulary",
                IsActive = true,
                Notes = "Notes"
            },
            new Category
            {
                Title = "General",
                Description = "All topics in General",
                IsActive = true,
                Notes = "Notes"
            },
        };

        await context.Categories.AddRangeAsync(categories);
        await context.SaveChangesAsync();
      }
    }
  }
}
