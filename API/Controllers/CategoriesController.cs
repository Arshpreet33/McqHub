using Application.Categories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class CategoriesController : BaseApiController
  {
    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
      return HandleResult(await Mediator.Send(new List.Query()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategories(Guid id)
    {
      return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
    }
  }
}