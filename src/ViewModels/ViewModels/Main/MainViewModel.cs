using System.Windows.Input;
using BAJIEPA.Senticode.Wpf.Base;
using Common.Items;
using Unity;

namespace ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        public MainViewModel(IUnityContainer container) : base(container)
        {
        }

        private SpreadsheetOutputProcessParameters GetOutputProcessParameters() =>
            new SpreadsheetOutputProcessParameters
            {
                CustomDelimiter = OutputParserConfiguration.CustomDelimiter,
                Delimiter = OutputParserConfiguration.Delimiter,
                RowLeft = OutputParserConfiguration.RowLeft,
                RowRight = OutputParserConfiguration.RowRight,
                WordLeft = OutputParserConfiguration.WordLeft,
                WordRight = OutputParserConfiguration.WordRight,
                TextCase = OutputTextCase
            };

        private SpreadsheetInputProcessParameters GetInputProcessParameters() =>
            new SpreadsheetInputProcessParameters
            {
                CustomDelimiter = InputParserConfiguration.CustomDelimiter,
                Delimiter = InputParserConfiguration.Delimiter,
                RowLeft = InputParserConfiguration.RowLeft,
                RowRight = InputParserConfiguration.RowRight,
                WordLeft = InputParserConfiguration.WordLeft,
                WordRight = InputParserConfiguration.WordRight
            };

        #region QuickProcess command

        public ICommand QuickProcessCommand => _quickProcessCommand ??=
                                                   new Command(ExecuteQuickProcess);

        private Command _quickProcessCommand;

        private void ExecuteQuickProcess(object parameter)
        {
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
            CopyFromClipboardCommand.Execute(null);
            ProcessInputCommand.Execute(null);
            ProcessOutputToNumericInsertCommand.Execute(null);
        }

        #endregion
    }
}