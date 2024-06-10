using CookiesCookbookRV.Recipes.Ingredients;

namespace CookiesCookbookRV.Recipes;

public class Recipe(IEnumerable<Ingredient> ingredients) {
    public IEnumerable<Ingredient> Ingredients { get; } = ingredients;

    public override string ToString() {
        var steps = Ingredients.Select(ingredient => $"{ingredient.Name}. {ingredient.PreparationInstructions}");
        return string.Join(Environment.NewLine, steps);
    }
}