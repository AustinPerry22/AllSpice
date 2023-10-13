namespace AllSpice.Controllers;

[ApiController]
[Route("api/ingredients")]

public class IngredientsController : ControllerBase
{
    private readonly IngredientsService _ingredientsService;
    private readonly Auth0Provider _auth0;
    public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0)
    {
        _ingredientsService = ingredientsService;
        _auth0 = auth0;
    }

    // REQUESTS
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient ingredientData)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            Ingredient ingredient = _ingredientsService.CreateIngredient(ingredientData, userInfo);
            return ingredient;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }
}