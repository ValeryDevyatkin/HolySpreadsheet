using System.Windows.Input;
using BAJIEPA.Senticode.Wpf.Base;
using Unity;

namespace ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        public MainViewModel(IUnityContainer container) : base(container)
        {
        }

        #region QuickProcess command

        public ICommand QuickProcessCommand => _quickProcessCommand ??=
                                                   new Command(ExecuteQuickProcess);

        private Command _quickProcessCommand;

        private void ExecuteQuickProcess(object parameter)
        {
            ClearAllCommand.Execute(null);
            CopyFromClipboardCommand.Execute(null);
            ProcessInputCommand.Execute(null);
            ProcessOutputCommand.Execute(null);
        }

        #endregion

        #region QuickProcessSqlStringInsert command

        public ICommand QuickProcessSqlStringInsertCommand => _quickProcessSqlStringInsertCommand ??=
                                                                  new Command(ExecuteQuickProcessSqlStringInsert);

        private Command _quickProcessSqlStringInsertCommand;

        private void ExecuteQuickProcessSqlStringInsert(object parameter)
        {
            ClearAllCommand.Execute(null);
            CopyFromClipboardCommand.Execute(null);
            ProcessInputCommand.Execute(null);
            ProcessOutputToSqlStringInsertCommand.Execute(null);
        }

        #endregion

        #region QuickProcessSqlNumericInsert command

        public ICommand QuickProcessSqlNumericInsertCommand => _quickProcessSqlNumericInsertCommand ??=
                                                                   new Command(ExecuteQuickProcessSqlNumericInsert);

        private Command _quickProcessSqlNumericInsertCommand;

        private void ExecuteQuickProcessSqlNumericInsert(object parameter)
        {
            ClearAllCommand.Execute(null);
            CopyFromClipboardCommand.Execute(null);
            ProcessInputCommand.Execute(null);
            ProcessOutputToNumericInsertCommand.Execute(null);
        }

        #endregion

        #region QuickProcessSqlStringIn command

        public ICommand QuickProcessSqlStringInCommand => _quickProcessSqlStringInCommand ??=
                                                              new Command(ExecuteQuickProcessSqlStringIn);

        private Command _quickProcessSqlStringInCommand;

        private void ExecuteQuickProcessSqlStringIn(object parameter)
        {
            ClearAllCommand.Execute(null);
            CopyFromClipboardCommand.Execute(null);
            ProcessInputCommand.Execute(null);
            ProcessOutputToStringInCommand.Execute(null);
        }

        #endregion

        #region QuickProcessSqlNumericIn command

        public ICommand QuickProcessSqlNumericInCommand => _quickProcessSqlNumericInCommand ??=
                                                               new Command(ExecuteQuickProcessSqlNumericIn);

        private Command _quickProcessSqlNumericInCommand;

        private void ExecuteQuickProcessSqlNumericIn(object parameter)
        {
            ClearAllCommand.Execute(null);
            CopyFromClipboardCommand.Execute(null);
            ProcessInputCommand.Execute(null);
            ProcessOutputToNumericInCommand.Execute(null);
        }

        #endregion

        #region ClearAll command

        public ICommand ClearAllCommand => _clearAllCommand ??=
                                               new Command(ExecuteClearAll);

        private Command _clearAllCommand;

        private void ExecuteClearAll(object parameter)
        {
            ClearOutputCommand.Execute(null);
            ClearGridCommand.Execute(null);
            ClearInputCommand.Execute(null);
        }

        #endregion
    }
}