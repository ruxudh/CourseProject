using CookiesCookbookRV.App;
using CookiesCookbookRV.FileFormat;
using CookiesCookbookRV.FileWriter;
using CookiesCookbookRV.Recipes;
using CookiesCookbookRV.Recipes.Ingredients;

const FileFormat fileFormat = FileFormat.Json;

IFileWriter fileWriter = fileFormat switch {
    FileFormat.Json => new StringFileWriter(),
    FileFormat.Txt => new StringTextualRepository(),
    _ => new StringFileWriter()
};

var filePath = fileFormat switch {
    FileFormat.Json => "ingredients.json",
    FileFormat.Txt => "ingredients.txt",
    _ => "ingredients.json"
};

var cookiesCookbookApp = new CookiesCookbookApp(
    new RecipesStorage(fileWriter),
    new RecipesConsoleUserInteraction(new IngredientsRegister())
);

cookiesCookbookApp.Run(filePath);