namespace CookiesCookbookRV.FileWriter;

public class StringTextualRepository : FileWriter {
    private static readonly string Separator = Environment.NewLine;
    protected override List<string> TextToStrings(string content) => content.Split(Separator).ToList();

    protected override string StringsToText(List<string> content) => string.Join(Separator, content);
}
