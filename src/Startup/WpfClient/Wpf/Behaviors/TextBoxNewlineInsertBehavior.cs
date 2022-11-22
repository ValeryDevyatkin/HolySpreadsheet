using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace WpfClient.Wpf.Behaviors
{
    public class TextBoxNewlineInsertBehavior : Behavior<TextBox>
    {
        private const string NewlineArtifact = "\r\n";

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.KeyUp += AssociatedObjectOnKeyUp;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.KeyUp -= AssociatedObjectOnKeyUp;
        }

        private void AssociatedObjectOnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var caretIndex = AssociatedObject.CaretIndex;

                AssociatedObject.Text = AssociatedObject.Text.Insert(caretIndex, NewlineArtifact);
                AssociatedObject.CaretIndex = caretIndex + NewlineArtifact.Length;
            }
        }
    }
}