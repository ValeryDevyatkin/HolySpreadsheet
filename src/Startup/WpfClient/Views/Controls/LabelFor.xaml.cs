using System.Windows;

namespace WpfClient.Views.Controls
{
    public partial class LabelFor
    {
        public LabelFor()
        {
            InitializeComponent();
        }

        #region Label dependency: string

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(
                nameof(Label),
                typeof(string),
                typeof(LabelFor),
                new PropertyMetadata(default(string)));

        public string Label
        {
            get => (string) GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        #endregion
    }
}