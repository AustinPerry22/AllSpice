

namespace AllSpice.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _repo;

    public FavoritesService(FavoritesRepository repo)
    {
        _repo = repo;
    }


    // INTERNALS
    internal Favorite CreateFavorite(Favorite favoriteData, Account userInfo)
    {
        favoriteData.AccountId = userInfo.Id;
        Favorite favorite = _repo.CreateFavorite(favoriteData);
        return favorite;
    }


    internal List<RecipeFavoriteViewModel> GetAccountFavorites(string userId)
    {
        List<RecipeFavoriteViewModel> favorites = _repo.GetAccountFavorites(userId);
        return favorites;
    }
    internal void DeleteFavorite(int favoriteId)
    {
        _repo.DeleteFavorite(favoriteId);
    }
}