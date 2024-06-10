using CookiesCookbookRV.FileWriter;
using CookiesCookbookRV.Recipes.Ingredients;

namespace CookiesCookbookRV.Recipes;

public class RecipesStorage(IFileWriter fileWriter) : IRecipesStorage {
    private readonly IngredientsRegister _ingredientsRegister = new();
    private const char Separator = ',';

    public List<Recipe> Read(string filePath) 
        => fileWriter
            .Read(filePath)
            .Select(RecipeFromString)
            .ToList();


    private Recipe RecipeFromString(string recipeAsString) {
        var ingredients = recipeAsString
            .Split(Separator)
            .Select(int.Parse)
            .Select(id => _ingredientsRegister.All.Find(ingredient => ingredient.Id == id))
            .ToList();
        return new Recipe(ingredients!);
    }

    public void Write(string filePath, List<Recipe> allRecipes) {
        var allRecipesAsStringTwo = allRecipes
            .Select(recipe => recipe.Ingredients
                .Select(ingredient => ingredient.Id))
            .Select(listOfId => string.Join(Separator, listOfId));

        fileWriter.Write(filePath, allRecipesAsStringTwo.ToList());
    }
}