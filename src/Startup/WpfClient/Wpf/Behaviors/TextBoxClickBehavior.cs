using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace WpfClient.Wpf.Behaviors
{
    public class TextBoxClickBehavior : Behavior<TextBox>
    {
        private const string TextBoxViewTypeName = "TextBoxView";
        private bool _isCanBeFired;

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.PreviewMouseLeftButtonDown += AssociatedObjectOnPreviewMouseLeftButtonDown;
            AssociatedObject.PreviewMouseLeftButtonUp += AssociatedObjectOnPreviewMouseLeftButtonUp;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.PreviewMouseLeftButtonDown -= AssociatedObjectOnPreviewMouseLeftButtonDown;
            AssociatedObject.PreviewMouseLeftButtonUp -= AssociatedObjectOnPreviewMouseLeftButtonUp;
        }

        private void AssociatedObjectOnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (IsActionDisabled)
            {
                return;
            }

            if (e.OriginalSource.GetType().Name != TextBoxViewTypeName)
            {
                return;
            }

            _isCanBeFired = true;
        }

        private void AssociatedObjectOnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (IsActionDisabled)
            {
                return;
            }

            if (e.OriginalSource.GetType().Name != TextBoxViewTypeName)
            {
                return;
            }

            if (_isCanBeFired)
            {
                Command?.Execute(null);
            }

            _isCanBeFired = false;
        }

        #region IsActionDisabled dependency: bool

        public static readonly DependencyProperty IsActionDisabledProperty =
            DependencyProperty.Register(
                nameof(IsActionDisabled),
                typeof(bool),
                typeof(TextBoxClickBehavior),
                new PropertyMetadata(default(bool)));

        public bool IsActionDisabled
        {
            get => (bool) GetValue(IsActionDisabledProperty);
            set => SetValue(IsActionDisabledProperty, value);
        }

        #endregion

        #region Command dependency: ICommand

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                nameof(Command),
                typeof(ICommand),
                typeof(TextBoxClickBehavior),
                new PropertyMetadata(default(ICommand)));

        public ICommand Command
        {
            get => (ICommand) GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        #endregion
    }
}