using CookiesCookbookRV.Recipes;

namespace CookiesCookbookRV.App;

public class CookiesCookbookApp(
    IRecipesStorage recipesStorage,
    IRecipesUserInteraction recipesUserInteraction
) {
    public void Run(string filePath) {
        var allRecipes = recipesStorage.Read(filePath);
        recipesUserInteraction.PrintAllRecipes(allRecipes);
        recipesUserInteraction.PromptToCreateARecipe();

        var ingredients = recipesUserInteraction.ReadIngredients();
        if (ingredients.Count != 0) {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);
            recipesStorage.Write(filePath, allRecipes);
            recipesUserInteraction.ShowMassage("Recipe have been saved to a file");
            recipesUserInteraction.ShowMassage(recipe.ToString());
            recipesUserInteraction.Exit();
        }
        else {
            recipesUserInteraction.ShowMassage("Now ingredients have been selected. Recipe won't be saved");
        }
    }
}