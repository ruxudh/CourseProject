namespace CookiesCookbookRV.FileWriter;

public interface IFileWriter {
    List<string> Read(string filePath);
    void Write(string filePath, List<string> strings);
}