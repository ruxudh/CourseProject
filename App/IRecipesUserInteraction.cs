using CookiesCookbookRV.Recipes;
using CookiesCookbookRV.Recipes.Ingredients;

namespace CookiesCookbookRV.App;

public interface IRecipesUserInteraction {
    void ShowMassage(string massage);
    void Exit();
    void PrintAllRecipes(List<Recipe> allRecipes);
    void PromptToCreateARecipe();
    List<Ingredient> ReadIngredients();
}