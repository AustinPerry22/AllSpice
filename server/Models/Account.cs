namespace AllSpice.Models;

public class Account
{
  public string Id { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
  public string Picture { get; set; }
}

public class AccountFavoriteViewModel : Account
{
  public int FavoriteId { get; set; }
  public string RecipeId { get; set; }
}
