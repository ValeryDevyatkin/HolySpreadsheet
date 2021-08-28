using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Common.Interfaces;
using Microsoft.Win32;
using Unity;

namespace WpfClient.Services
{
    internal class FileDialogService : IFileDialogService
    {
        private const string Filter = "(*.txt)|*.txt|(*.csv)|*.csv|(*.xlsx)|*.xlsx";

        private readonly string _initialDirectory =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Downloads");

        public FileDialogService(IUnityContainer container)
        {
            container.RegisterInstance(this);
        }

        public async Task SaveToFileAsync(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            var dialog = new SaveFileDialog
            {
                InitialDirectory = _initialDirectory,
                CheckPathExists = true,
                CheckFileExists = true,
                Filter = Filter
            };

            if (dialog.ShowDialog(Application.Current.MainWindow) == true)
            {
                await File.WriteAllTextAsync(dialog.FileName, text);
            }
        }

        public async Task<string> ReadFromFileAsync()
        {
            var dialog = new OpenFileDialog
            {
                InitialDirectory = _initialDirectory,
                CheckPathExists = true,
                CheckFileExists = true,
                Filter = Filter
            };

            return dialog.ShowDialog(Application.Current.MainWindow) == true ?
                       await File.ReadAllTextAsync(dialog.FileName) :
                       null;
        }
    }
}