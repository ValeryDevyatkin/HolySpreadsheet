using System.Windows;

namespace WpfClient.Views.Controls
{
    public partial class EnumRadioGroup
    {
        public EnumRadioGroup()
        {
            InitializeComponent();
            GroupName = GetHashCode().ToString();
            Loaded += OnLoaded;
        }

        public string GroupName { get; }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (GroupValue != null)
            {
                ItemsControl.ItemsSource = GroupValue.GetType().GetEnumValues();
            }
        }

        #region GroupValue dependency: object

        public static readonly DependencyProperty GroupValueProperty =
            DependencyProperty.Register(
                nameof(GroupValue),
                typeof(object),
                typeof(EnumRadioGroup),
                new PropertyMetadata(default(object)));

        public object GroupValue
        {
            get => GetValue(GroupValueProperty);
            set => SetValue(GroupValueProperty, value);
        }

        #endregion
    }
}