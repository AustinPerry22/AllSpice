


namespace AllSpice.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    // INTERNALS
    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        string sql = @"
        INSERT INTO favorites
        (accountId, recipeId)
        VALUES
        (@accountId, @recipeId);

        SELECT LAST_INSERT_ID()
        ;";
        int lastInsertId = _db.ExecuteScalar<int>(sql, favoriteData);
        favoriteData.Id = lastInsertId;
        return favoriteData;
    }

    internal List<RecipeFavoriteViewModel> GetAccountFavorites(string accountId)
    {
        string sql = @"
        SELECT
        fav.*,
        rec.*  
        FROM favorites fav
        JOIN recipes rec ON rec.id = fav.recipeId
        WHERE fav.accountId = @accountId
        ;";
        List<RecipeFavoriteViewModel> myFavorites = _db.Query<Favorite, RecipeFavoriteViewModel, RecipeFavoriteViewModel>(sql, (favorite, recipe) =>
        {
            recipe.FavoriteId = favorite.Id;
            recipe.AccountId = favorite.AccountId;
            return recipe;
        }, new { accountId }).ToList();
        return myFavorites;
    }

    internal void DeleteFavorite(int favoriteId)
    {
        string sql = @"
        DELETE FROM favorites
        WHERE id = @favoriteId
        LIMIT 1
        ;";
        _db.Execute(sql, new { favoriteId });
    }
}