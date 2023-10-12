



namespace AllSpice.Repositories;

public class RecipesRepository
{
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        string sql = @"
        INSERT INTO recipes
        (title, instructions, img, category, creatorId)
        Values
        (@title, @instructions, @img, @category, @creatorId);

        SELECT
        act.*,
        rec.*
        FROM recipes rec
        JOIN accounts act ON act.id = rec.creatorId
        WHERE rec.id = LAST_INSERT_ID()
        ;";

        Recipe recipe = _db.Query<Account, Recipe, Recipe>(sql, (acount, recipe) =>
        {
            recipe.Creator = acount;
            return recipe;
        }, recipeData).FirstOrDefault();
        return recipe;
    }



    internal Recipe GetRecipeById(int recipeId)
    {
        string sql = @"
        SELECT
        rec.*,
        act.*
        FROM recipes rec
        JOIN accounts act ON act.id = rec.creatorId
        WHERE rec.id = @recipeId
        ;";
        Recipe foundRecipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }, new { recipeId }).FirstOrDefault();
        return foundRecipe;
    }

    internal List<Recipe> GetRecipes()
    {
        string sql = @"
        SELECT 
        rec.*,
        act.*
        FROM recipes rec
        JOIN accounts act ON act.id = rec.creatorId
        ;";

        List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }).ToList();
        return recipes;
    }

    internal Recipe EditRecipe(Recipe og)
    {
        string sql = @"
        UPDATE recipes
        SET
        title = @title,
        instructions = @instructions,
        img = @img,
        category = @category
        WHERE id = @id;
        
        SELECT 
        rec.*,
        act.*
        FROM recipes rec
        JOIN accounts act ON act.id = rec.creatorId
        WHERE rec.id = @id
        ;";

        Recipe recipe = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }, og).FirstOrDefault();
        return recipe;
    }
}