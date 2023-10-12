



namespace AllSpice.Services;

public class RecipesService
{
    private readonly RecipesRepository _repo;


    public RecipesService(RecipesRepository repo)
    {
        _repo = repo;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = _repo.CreateRecipe(recipeData);
        return recipe;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        Recipe recipe = _repo.GetRecipeById(recipeId);
        if (recipe == null) throw new Exception("No recipe with Id " + recipe.Id);
        return recipe;
    }

    internal Recipe EditRecipe(Recipe recipeData)
    {
        Recipe og = this.GetRecipeById(recipeData.Id);
        if (og.CreatorId != recipeData.CreatorId) throw new Exception("You Don't Own This!");
        og.Title = recipeData.Title ?? og.Title;
        og.Instructions = recipeData.Instructions ?? og.Instructions;
        og.Img = recipeData.Img ?? og.Img;
        og.Category = recipeData.Category ?? og.Category;

        Recipe recipe = _repo.EditRecipe(og);
        return recipe;

    }

    internal List<Recipe> GetRecipes()
    {
        List<Recipe> recipes = _repo.GetRecipes();
        return recipes;
    }

    internal void DeleteRecipe(int recipeId, string userId)
    {
        Recipe og = this.GetRecipeById(recipeId);
        if (og.CreatorId != userId) throw new Exception("You Don't Own this!");
        _repo.DeleteRecipe(recipeId);
    }

    // INTERALS
}