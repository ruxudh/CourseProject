namespace CookiesCookbookRV.Recipes;

public interface IRecipesStorage {
    List<Recipe> Read(string filePath);
    void Write(string filePath, List<Recipe> allRecipes);
}