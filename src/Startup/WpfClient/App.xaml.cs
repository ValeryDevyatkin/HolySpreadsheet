using System;
using System.Windows;
using System.Windows.Threading;
using BAJIEPA.Senticode.Wpf;
using BAJIEPA.Senticode.Wpf.Helpers;
using BAJIEPA.Senticode.Wpf.Interfaces;
using Common.Interfaces;
using Services;
using Unity;
using ViewModels;
using WpfClient.Services;
using WpfClient.Views.Regions;

namespace WpfClient
{
    internal partial class App
    {
        public App() : base(ServiceLocator.Container)
        {
        }

        public override void BlockUiForCommand(ICommandInfo command)
        {
            var mainViewModel = Container.Resolve<MainViewModel>();
            mainViewModel.ProgressText = command.ProgressText;
            mainViewModel.IsPreLoaderVisible = true;
            MainWindow?.Dispatcher.Invoke(DispatcherPriority.Render, new Action(() => { }));
        }

        public override void UnlockUiForCommand(ICommandInfo command)
        {
            var mainViewModel = Container.Resolve<MainViewModel>();
            mainViewModel.IsPreLoaderVisible = false;
            mainViewModel.ProgressText = null;
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

            // Services.
            Container
               .RegisterSingleton<IFileDialogService, FileDialogService>()
               .RegisterSingleton<IDataGridService, DataGridService>()
               .RegisterSingleton<IMessageDialogService, MessageDialogService>()
                ;

            // Views.
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
            // Do not extract this code block. It is under control of IoC.
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}