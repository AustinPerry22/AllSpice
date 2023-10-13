

namespace AllSpice.Services;

public class IngredientsService
{
    private readonly IngredientsRepository _repo;

    private readonly RecipesService _recipesService;

    public IngredientsService(IngredientsRepository repo, RecipesService recipesService)
    {
        _repo = repo;
        _recipesService = recipesService;
    }

    // INTERNALS
    internal Ingredient CreateIngredient(Ingredient ingredientData, Account userInfo)
    {
        Recipe recipe = _recipesService.GetRecipeById(ingredientData.recipeId);
        if (recipe.CreatorId != userInfo.Id) throw new Exception("You don't own this recipe");
        Ingredient ingredient = _repo.CreateIngredient(ingredientData);
        return ingredient;
    }

    internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
    {
        List<Ingredient> ingredients = _repo.GetIngredientsByRecipe(recipeId);
        return ingredients;
    }
}