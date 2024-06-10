namespace CookiesCookbookRV.FileWriter;

public abstract class FileWriter : IFileWriter {
    public void Write(string filePath, List<string> strings) {
        File.WriteAllText(filePath, StringsToText(strings));
    }

    public List<string> Read(string filePath) {
        if (File.Exists(filePath)) {
            var fileContent = File.ReadAllText(filePath);
            return TextToStrings(fileContent);
        }

        return [];
    }

    protected abstract List<string> TextToStrings(string content);
    protected abstract string StringsToText(List<string> content);
}