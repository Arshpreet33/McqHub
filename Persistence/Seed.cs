using Domain;

namespace Persistence
{
  public class Seed
  {
    public static async Task SeedData(DataContext context)
    {
      if (!context.Categories.Any())
      {
        var categories = GetCategories();

        foreach (var item in categories)
        {
          if (item.Title == "p") item.Topics = await LoadJsonData.GetProgrammingTopic(item.Title);
          else item.Topics = await LoadJsonData.GetTopics(item.Title);

        }

        await context.Categories.AddRangeAsync(categories);
        await context.SaveChangesAsync();
      }
    }

    private static List<Category> GetCategories()
    {
      return new List<Category>
        {
            new Category
            {
                Title = "Programming",
                Description = "All topics in Programming Category",
                IsActive = true,
                Notes = ""
            },
            new Category
            {
                Title = "Entertainment",
                Description = "All topics in Entertainment Category",
                IsActive = true,
                Notes = ""
            },
            new Category
            {
                Title = "Science",
                Description = "All topics in Science Category",
                IsActive = true,
                Notes = ""
            },
            new Category
            {
                Title = "Miscellaneous",
                Description = "All topics in Miscellaneous Category",
                IsActive = true,
                Notes = ""
            }
        };
    }
  }
}
