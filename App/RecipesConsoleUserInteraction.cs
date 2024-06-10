using CookiesCookbookRV.Recipes;
using CookiesCookbookRV.Recipes.Ingredients;

namespace CookiesCookbookRV.App;

public class RecipesConsoleUserInteraction(
    IngredientsRegister ingredientsRegister
) : IRecipesUserInteraction {
    public void ShowMassage(string massage) => Console.WriteLine(massage);

    public void Exit() {
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }

    public void PrintAllRecipes(List<Recipe> allRecipes) {
        
        if (allRecipes.Count == 0) return;
        
        var allRecipesAsString = allRecipes
            .Select((recipe, index) => $"""
                                        ******{index + 1}******
                                        {recipe}
                                        """);
        Console.WriteLine(string.Join(Environment.NewLine, allRecipesAsString));
        Console.WriteLine();
    }

    public void PromptToCreateARecipe() {
        Console.WriteLine("Create a new recipe! Available ingredients are:");
        var allExistingRecipes = string.Join(Environment.NewLine, ingredientsRegister.All);
        Console.WriteLine(allExistingRecipes);
    }

    public List<Ingredient> ReadIngredients() {
        var shallStop = false;
        var ingredients = new List<Ingredient>();
        while (!shallStop) {
            Console.WriteLine("Choose an ingredient by it's ID, or write anything else if finished.");
            var userInput = Console.ReadLine();
            if (int.TryParse(userInput, out var id)) {
                var ingredient = ingredientsRegister.All.Find(i => i.Id == id);
                if (ingredient is not null) ingredients.Add(ingredient);
            }
            else {
                shallStop = true;
            }
        }

        return ingredients;
    }
}