using System.Diagnostics;


namespace Shared.Services;

public class FileService : IFileService
{
    private readonly string _filePath;

    public FileService(string filePath)  // constructor
    {
        _filePath = filePath;

    }

    public bool SaveToFile(string content)  // Create SW and write the content to the file
    {
        try
        {
            using StreamWriter sw = new StreamWriter(_filePath);
            sw.Write(content);
            Debug.WriteLine("file saved with new product" + $" using this path {_filePath}");
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
    public string GetFromFile() // Create SR and read the content of the file
    {
        try
        {
            if (File.Exists(_filePath))
            {
                using StreamReader sr = new StreamReader(_filePath);
                string content = sr.ReadToEnd();
                return content;
            }
            return null!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null!;
        }
    }
}

