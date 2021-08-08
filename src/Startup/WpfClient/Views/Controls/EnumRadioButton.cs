using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfClient.Views.Controls
{
    public class EnumRadioButton : RadioButton
    {
        public EnumRadioButton()
        {
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (CurrentValue != null && GroupValue != null)
            {
                GroupName = CurrentValue.GetType().Name;
                Content = CurrentValue.ToString();

                if (Equals(CurrentValue, GroupValue))
                {
                    IsChecked = true;
                }
            }
        }

        #region CurrentValue dependency: Enum

        public static readonly DependencyProperty CurrentValueProperty =
            DependencyProperty.Register(
                nameof(CurrentValue),
                typeof(Enum),
                typeof(EnumRadioButton),
                new PropertyMetadata(default(Enum)));

        public Enum CurrentValue
        {
            get => (Enum) GetValue(CurrentValueProperty);
            set => SetValue(CurrentValueProperty, value);
        }

        #endregion

        #region GroupValue dependency: Enum

        public static readonly DependencyProperty GroupValueProperty =
            DependencyProperty.Register(
                nameof(GroupValue),
                typeof(Enum),
                typeof(EnumRadioButton),
                new PropertyMetadata(default(Enum), GroupValuePropertyChangedCallback));

        private static void GroupValuePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is EnumRadioButton radio)
            {
                if (Equals(radio.GroupValue, radio.CurrentValue))
                {
                    radio.IsChecked = true;
                }
            }
        }

        public Enum GroupValue
        {
            get => (Enum) GetValue(GroupValueProperty);
            set => SetValue(GroupValueProperty, value);
        }

        #endregion
    }
}