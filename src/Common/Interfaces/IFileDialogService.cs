using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IFileDialogService
    {
        Task<string> ReadFromFileAsync();
        Task SaveToFileAsync(string text);
    }
}