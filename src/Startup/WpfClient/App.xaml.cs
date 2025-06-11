using System;
using System.Windows;
using System.Windows.Threading;
using BAJIEPA.Senticode.Wpf;
using BAJIEPA.Tools.Logging;
using Common.Interfaces;
using Services;
using Unity;
using ViewModels;
using ViewModels.Main;
using WpfClient.Services;
using WpfClient.Views;
using WpfClient.Views.Regions;

namespace WpfClient
{
    internal partial class App : ApplicationBase<MainWindow, MainViewModel>
    {
        public App() : base(ServiceLocator.Container)
        {
        }

        protected override async void OnStartup(StartupEventArgs args)
        {
            try
            {
                await AppUpdateHelper.CheckForUpdatesAsync();
                base.OnStartup(args);
                CreateMainWindow().Show();
            }
            catch (Exception e)
            {
                this.HandleException(e);

                throw;
            }
        }

        protected override void RegisterTypes()
        {
            base.RegisterTypes();

            ServicesInitializer.Init(Container);
            ViewModelsInitializer.Init(Container);

            // Services
            Container
               .RegisterSingleton<IFileDialogService, FileDialogService>()
               .RegisterSingleton<IDataGridService, DataGridService>()
               .RegisterSingleton<IMessageDialogService, MessageDialogService>()
                ;

            // Views
            Container
               .RegisterType<GridRegion>()
                ;
        }

        protected override void OnExit(ExitEventArgs args)
        {
            try
            {
                base.OnExit(args);
            }
            catch (Exception e)
            {
                this.HandleException(e);
            }
        }

        protected override void HandleExceptionExternal(ExceptionLogItem ex)
        {
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}