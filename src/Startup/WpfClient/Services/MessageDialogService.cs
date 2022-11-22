using System.Windows;
using Common.Interfaces;

namespace WpfClient.Services
{
    internal class MessageDialogService : IMessageDialogService
    {
        public void ShowWarning(string text, string caption)
        {
            MessageBox.Show(
                text,
                caption,
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }
    }
}