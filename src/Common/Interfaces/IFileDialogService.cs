using System.Threading.Tasks;
using Common.Items;

namespace Common.Interfaces
{
    public interface IFileDialogService
    {
        Task<OpenFileDialogResult> ReadFromFileAsync();
        Task SaveToFileAsync(string text);
    }
}