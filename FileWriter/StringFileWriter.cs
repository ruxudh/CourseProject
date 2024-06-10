using System.Text.Json;

namespace CookiesCookbookRV.FileWriter;

public class StringFileWriter : FileWriter {
    protected override string StringsToText(List<string> content) => JsonSerializer.Serialize(content);
    

    protected override List<string> TextToStrings(string content) => JsonSerializer.Deserialize<List<String>>(content)!;
}