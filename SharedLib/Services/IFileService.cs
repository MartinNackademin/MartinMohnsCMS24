namespace Shared.Services
{
    public interface IFileService
    {
        string GetFromFile();
        bool SaveToFile(string content);
    }
}