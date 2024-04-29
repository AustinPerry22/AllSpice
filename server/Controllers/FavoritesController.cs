using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace AllSpice.Controllers;

[ApiController]
[Route("api/favorites")]
public class FavortiesController : ControllerBase
{
    private readonly FavoritesService _favoritesService;

    private readonly Auth0Provider _auth0;

    public FavortiesController(FavoritesService favoritesService, Auth0Provider auth0)
    {
        _favoritesService = favoritesService;
        _auth0 = auth0;
    }

    // REQUESTS
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite favoriteData)
    {
        try
        {
            Account userInfo = await _auth0.GetUserInfoAsync<Account>(HttpContext);
            Favorite favorite = _favoritesService.CreateFavorite(favoriteData, userInfo);
            return favorite;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpDelete("{favoriteId}")]
    public ActionResult<string> DeleteFavorite(int favoriteId)
    {
        try
        {
            _favoritesService.DeleteFavorite(favoriteId);
            return "Favorite Deleted";
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}