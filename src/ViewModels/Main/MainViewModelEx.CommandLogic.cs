using System;
using System.Threading.Tasks;
using System.Windows;
using Common.Interfaces;
using Common.Items;
using Unity;

namespace ViewModels.Main
{
    internal static partial class MainViewModelEx
    {
        public static async Task ProcessInputAsync(this MainViewModel viewModel)
        {
            if (string.IsNullOrWhiteSpace(viewModel.InputText))
            {
                return;
            }

            var container = viewModel.Container;
            var parameters = viewModel.GetInputProcessParameters();

            SpreadsheetInputProcessResult result = null;

            await Task.Run(() =>
            {
                result = container
                    .Resolve<ISpreadsheetProcessor>()
                    .ProcessInput(viewModel.InputText, parameters);
            });

            ArgumentNullException.ThrowIfNull(result);

            viewModel.GridRowCount = result.RowCount;
            viewModel.GridColumnCount = result.ColumnCount;
            container.Resolve<IDataGridService>().PopulateRows(result);
        }

        public static async Task ProcessOutputAsync(this MainViewModel viewModel)
        {
            if (viewModel.GridRowCount < 1)
            {
                return;
            }

            var container = viewModel.Container;
            var parameters = viewModel.GetOutputProcessParameters();
            var gridParsingResult = container.Resolve<IDataGridService>().GetRows();

            SpreadsheetOutputProcessResult result = null;

            await Task.Run(() =>
            {
                result = container
                    .Resolve<ISpreadsheetProcessor>()
                    .ProcessOutput(gridParsingResult, parameters);
            });

            ArgumentNullException.ThrowIfNull(result);

            viewModel.SetOutputProcessResult(result);
        }

        public static async Task ProcessOutputToStringInsertAsync(this MainViewModel viewModel)
        {
            if (viewModel.GridRowCount < 1)
            {
                return;
            }

            var container = viewModel.Container;
            var parameters = SpreadsheetOutputProcessParameters.QuickSqlStringInsertPreset;
            var gridParsingResult = container.Resolve<IDataGridService>().GetRows();

            SpreadsheetOutputProcessResult result = null;

            await Task.Run(() =>
            {
                result = container
                    .Resolve<ISpreadsheetProcessor>()
                    .ProcessOutput(gridParsingResult, parameters);
            });

            ArgumentNullException.ThrowIfNull(result);

            viewModel.SetOutputProcessResult(result);
        }

        public static async Task ProcessOutputToNumericInsertAsync(this MainViewModel viewModel)
        {
            if (viewModel.GridRowCount < 1)
            {
                return;
            }

            var container = viewModel.Container;
            var parameters = SpreadsheetOutputProcessParameters.QuickSqlNumericInsertPreset;
            var gridParsingResult = container.Resolve<IDataGridService>().GetRows();

            SpreadsheetOutputProcessResult result = null;

            await Task.Run(() =>
            {
                result = container
                    .Resolve<ISpreadsheetProcessor>()
                    .ProcessOutput(gridParsingResult, parameters);
            });

            ArgumentNullException.ThrowIfNull(result);

            viewModel.SetOutputProcessResult(result);
        }

        public static async Task ProcessOutputToStringInAsync(this MainViewModel viewModel)
        {
            if (viewModel.GridRowCount < 1)
            {
                return;
            }

            var container = viewModel.Container;
            var parameters = SpreadsheetOutputProcessParameters.QuickSqlStringInPreset;
            var gridParsingResult = container.Resolve<IDataGridService>().GetRows();

            SpreadsheetOutputProcessResult result = null;

            await Task.Run(() =>
            {
                result = container
                    .Resolve<ISpreadsheetProcessor>()
                    .ProcessOutput(gridParsingResult, parameters);
            });

            ArgumentNullException.ThrowIfNull(result);

            viewModel.SetOutputProcessResult(result);
        }

        public static async Task ProcessOutputToNumericInAsync(this MainViewModel viewModel)
        {
            if (viewModel.GridRowCount < 1)
            {
                return;
            }

            var container = viewModel.Container;
            var parameters = SpreadsheetOutputProcessParameters.QuickSqlNumericInPreset;
            var gridParsingResult = container.Resolve<IDataGridService>().GetRows();

            SpreadsheetOutputProcessResult result = null;

            await Task.Run(() =>
            {
                result = container
                    .Resolve<ISpreadsheetProcessor>()
                    .ProcessOutput(gridParsingResult, parameters);
            });

            ArgumentNullException.ThrowIfNull(result);

            viewModel.SetOutputProcessResult(result);
        }

        public static void ClearGrid(this MainViewModel viewModel)
        {
            viewModel.GridRowCount = 0;
            viewModel.GridColumnCount = 0;
            viewModel.Container.Resolve<IDataGridService>().Clear();
        }

        public static void ClearInput(this MainViewModel viewModel)
        {
            viewModel.InputText = null;
        }

        public static void ClearOutput(this MainViewModel viewModel)
        {
            viewModel.OutputRowCount = 0;
            viewModel.OutputText = null;
        }

        public static void ClearAll(this MainViewModel viewModel)
        {
            viewModel.ClearOutput();
            viewModel.ClearGrid();
            viewModel.ClearInput();
        }

        public static void CopyFromClipboard(this MainViewModel viewModel)
        {
            var clipboardText = Clipboard.GetText();

            if (string.IsNullOrWhiteSpace(clipboardText))
            {
                viewModel.Container
                    .Resolve<IMessageDialogService>()
                    .ShowWarning("Clipboard has no text.", "Copy from Clipboard");
            }
            else
            {
                viewModel.InputText = clipboardText;
            }
        }

        public static void DeactivateAllColumns(this MainViewModel viewModel)
        {
            viewModel.Container
                .Resolve<IDataGridService>()
                .DeactivateAllColumns();
        }

        public static void ActivateAllColumns(this MainViewModel viewModel)
        {
            viewModel.Container
                .Resolve<IDataGridService>()
                .ActivateAllColumns();
        }
    }
}