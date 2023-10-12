
namespace AllSpice.Repositories;

public class RecipesRepository
{
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
        _db = db;
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
}