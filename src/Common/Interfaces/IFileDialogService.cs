using System.Threading.Tasks;
using Common.Items;

namespace Common.Interfaces
{
    // TODO: This is unused.
    public interface IFileDialogService
    {
        Task<OpenFileDialogResult> ReadFromFileAsync();
        Task SaveToFileAsync(string text);
    }
}