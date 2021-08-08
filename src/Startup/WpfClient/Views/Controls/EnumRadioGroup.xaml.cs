using System;
using System.Windows;

namespace WpfClient.Views.Controls
{
    public partial class EnumRadioGroup
    {
        public EnumRadioGroup()
        {
            InitializeComponent();

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (GroupValue != null)
            {
                ItemsControl.ItemsSource = GroupValue.GetType().GetEnumValues();
            }
        }

        #region GroupValue dependency: Enum

        public static readonly DependencyProperty GroupValueProperty =
            DependencyProperty.Register(
                nameof(GroupValue),
                typeof(Enum),
                typeof(EnumRadioGroup),
                new PropertyMetadata(default(Enum)));

        public Enum GroupValue
        {
            get => (Enum) GetValue(GroupValueProperty);
            set => SetValue(GroupValueProperty, value);
        }

        #endregion
    }
}