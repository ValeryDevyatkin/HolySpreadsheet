using BAJIEPA.Senticode.MVVM;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfClient.Views.Controls
{
    internal class CustomDataGridTextColumn : DataGridTextColumn
    {
        #region IsDeactivated dependency: bool

        public static readonly DependencyProperty IsDeactivatedProperty =
            DependencyProperty.Register(
                nameof(IsDeactivated),
                typeof(bool),
                typeof(CustomDataGridTextColumn),
                new PropertyMetadata(default(bool)));

        public bool IsDeactivated
        {
            get => (bool)GetValue(IsDeactivatedProperty);
            set => SetValue(IsDeactivatedProperty, value);
        }

        #endregion

        #region IsFormattingDeactivated dependency: bool

        public static readonly DependencyProperty IsFormattingDeactivatedProperty =
            DependencyProperty.Register(
                nameof(IsFormattingDeactivated),
                typeof(bool),
                typeof(CustomDataGridTextColumn),
                new PropertyMetadata(default(bool)));

        public bool IsFormattingDeactivated
        {
            get => (bool)GetValue(IsFormattingDeactivatedProperty);
            set => SetValue(IsFormattingDeactivatedProperty, value);
        }

        #endregion

        #region SwitchDeactivated command

        public ICommand SwitchDeactivatedCommand => _switchDeactivatedCommand ??=
            new Command(ExecuteSwitchDeactivated);

        private Command _switchDeactivatedCommand;

        private void ExecuteSwitchDeactivated(object parameter)
        {
            if (IsDeactivated)
            {
                Activate();
            }
            else
            {
                Deactivate();
            }
        }

        #endregion

        #region SwitchFormattingDeactivated command

        public ICommand SwitchFormattingDeactivatedCommand => _switchFormattingDeactivatedCommand ??=
            new Command(ExecuteSwitchFormattingDeactivated);

        private Command _switchFormattingDeactivatedCommand;

        private void ExecuteSwitchFormattingDeactivated(object parameter)
        {
            IsFormattingDeactivated = !IsFormattingDeactivated;
        }

        #endregion

        public void Deactivate()
        {
            IsDeactivated = true;
            IsFormattingDeactivated = false;
        }

        public void Activate()
        {
            IsDeactivated = false;
        }
    }
}