﻿using System.Threading.Tasks;
using System.Windows.Input;
using BAJIEPA.Senticode.MVVM;
using Common.Constants;
using Common.Enums;

namespace ViewModels.Main
{
    public partial class MainViewModel
    {
        #region ShouldPullInLine: bool

        public bool ShouldPullInLine
        {
            get => _shouldPullInLine;
            set => SetProperty(ref _shouldPullInLine, value);
        }

        private bool _shouldPullInLine;

        #endregion

        #region Delimiter: DelimiterEnum

        public DelimiterEnum Delimiter
        {
            get => _delimiter;
            set => SetProperty(ref _delimiter, value);
        }

        private DelimiterEnum _delimiter;

        #endregion

        #region CustomDelimiter: string

        public string CustomDelimiter
        {
            get => _customDelimiter;
            set => SetProperty(ref _customDelimiter, value);
        }

        private string _customDelimiter;

        #endregion

        #region GridRowCount: int

        public int GridRowCount
        {
            get => _gridRowCount;
            internal set => SetProperty(ref _gridRowCount, value);
        }

        private int _gridRowCount;

        #endregion

        #region GridColumnCount: int

        public int GridColumnCount
        {
            get => _gridColumnCount;
            set => SetProperty(ref _gridColumnCount, value);
        }

        private int _gridColumnCount;

        #endregion

        #region ProcessInput command

        public ICommand ProcessInputCommand => _processInputCommand ??=
            new AsyncCommand(
                Container,
                ExecuteProcessInputAsync,
                progressText: CommandProgressTextStrings.ProcessInput);

        private AsyncCommand _processInputCommand;

        private async Task ExecuteProcessInputAsync(object parameter)
        {
            await this.ProcessInputAsync();
        }

        #endregion

        #region ClearGrid command

        public ICommand ClearGridCommand => _clearGridCommand ??=
            new Command(ExecuteClearGrid);

        private Command _clearGridCommand;

        private void ExecuteClearGrid(object parameter)
        {
            this.ClearGrid();
        }

        #endregion

        #region DeactivateAllColumns command

        public ICommand DeactivateAllColumnsCommand => _deactivateAllColumnsCommand ??=
            new Command(ExecuteDeactivateAllColumns);

        private Command _deactivateAllColumnsCommand;

        private void ExecuteDeactivateAllColumns(object parameter)
        {
            this.DeactivateAllColumns();
        }

        #endregion

        #region ActivateAllColumns command

        public ICommand ActivateAllColumnsCommand => _activateAllColumnsCommand ??=
            new Command(ExecuteActivateAllColumns);

        private Command _activateAllColumnsCommand;

        private void ExecuteActivateAllColumns(object parameter)
        {
            this.ActivateAllColumns();
        }

        #endregion
    }
}