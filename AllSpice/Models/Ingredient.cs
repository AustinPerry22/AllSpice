namespace AllSpice.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string quantity { get; set; }
    public int recipeId { get; set; }
}