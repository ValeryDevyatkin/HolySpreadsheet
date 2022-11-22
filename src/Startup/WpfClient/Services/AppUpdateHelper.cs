using System.Threading.Tasks;
using System.Windows;
using Squirrel;

namespace WpfClient.Services
{
    internal static class AppUpdateHelper
    {
        public static async Task CheckForUpdatesAsync()
        {
            using var updateManager = new GithubUpdateManager("https://github.com/ValeryDeviatkin/HolySpreadsheet");

            if (!updateManager.IsInstalledApp)
            {
                return;
            }

            var updateResult = await updateManager.UpdateApp();

            if (updateResult != null)
            {
                var versionString = updateResult.Version.Version.ToString();

                // Do not extract this code block. It is under control of IoC.
                MessageBox.Show($"A new version {versionString} was downloaded. Please restart the app.");

                Application.Current.Shutdown();
            }
        }
    }
}