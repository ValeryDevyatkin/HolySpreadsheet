using System.Windows;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace WpfClient.Wpf.Behaviors
{
    internal class UiElementClickBehavior : Behavior<UIElement>
    {
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
            _isCanBeFired = true;
        }

        private void AssociatedObjectOnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_isCanBeFired)
            {
                Command?.Execute(null);
            }

            _isCanBeFired = false;
        }

        #region Command dependency: ICommand

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                nameof(Command),
                typeof(ICommand),
                typeof(UiElementClickBehavior),
                new PropertyMetadata(default(ICommand)));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        #endregion
    }
}