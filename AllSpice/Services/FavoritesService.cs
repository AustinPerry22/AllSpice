
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
}