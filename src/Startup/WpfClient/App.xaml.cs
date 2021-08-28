using System;
using System.Windows;
using BAJIEPA.Senticode.Wpf;
using BAJIEPA.Senticode.Wpf.Helpers;
using Common.Interfaces;
using Services;
using Unity;
using ViewModels;
using WpfClient.Services;

namespace WpfClient
{
    internal partial class App
    {
        public App() : base(ServiceLocator.Container)
        {
        }

        protected override void OnStartup(StartupEventArgs args)
        {
            ExceptionLogHelper.LogCriticalExceptionInRelease = exceptionItem => MessageBox.Show(
                exceptionItem.Message, exceptionItem.Source, MessageBoxButton.OK, MessageBoxImage.Error);

            try
            {
                base.OnStartup(args);
                CreateMainWindow().Show();
            }
            catch (Exception e)
            {
                this.LogCriticalException(e);

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
               .RegisterType<IFileDialogService, FileDialogService>()
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
                this.LogCriticalException(e);
            }
        }
    }
}