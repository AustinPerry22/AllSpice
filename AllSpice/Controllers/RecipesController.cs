namespace AllSpice.Controllers;

[ApiController]
[Route("api/recipes")]

public class RecipesController : ControllerBase
{
    private readonly RecipesService _recipesService;

    public RecipesController(RecipesService recipesService)
    {
        _recipesService = recipesService;
    }

    // HTTP METHODS
}