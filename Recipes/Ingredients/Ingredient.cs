namespace CookiesCookbookRV.Recipes.Ingredients;

public abstract class Ingredient {
    public abstract int Id { get; }
    public abstract string Name { get; }
    public abstract string PreparationInstructions { get; }

    public override string ToString() => $"{Id}. {Name}";
}


