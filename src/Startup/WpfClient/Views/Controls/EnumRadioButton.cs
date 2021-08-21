using System;
using System.Windows;
using System.Windows.Controls;
using Common.Helpers;

namespace WpfClient.Views.Controls
{
    public class EnumRadioButton : RadioButton
    {
        public EnumRadioButton()
        {
            Loaded += OnLoaded;
        }

        private void OnChecked(object sender, RoutedEventArgs e)
        {
            GroupValue = CurrentValue;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (CurrentValue is Enum currentEnumValue && GroupValue is Enum)
            {
                var enumDisplayInfo = currentEnumValue.GetDisplayInfo();
                Content = enumDisplayInfo.Name;
                ToolTip = enumDisplayInfo.Description;

                if (Equals(CurrentValue, GroupValue))
                {
                    IsChecked = true;
                }

                Checked += OnChecked;
            }
        }

        #region CurrentValue dependency: object

        public static readonly DependencyProperty CurrentValueProperty =
            DependencyProperty.Register(
                nameof(CurrentValue),
                typeof(object),
                typeof(EnumRadioButton),
                new PropertyMetadata(default(object)));

        public object CurrentValue
        {
            get => GetValue(CurrentValueProperty);
            set => SetValue(CurrentValueProperty, value);
        }

        #endregion

        #region GroupValue dependency: object

        public static readonly DependencyProperty GroupValueProperty =
            DependencyProperty.Register(
                nameof(GroupValue),
                typeof(object),
                typeof(EnumRadioButton),
                new PropertyMetadata(default, GroupValuePropertyChangedCallback));

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

        public object GroupValue
        {
            get => GetValue(GroupValueProperty);
            set => SetValue(GroupValueProperty, value);
        }

        #endregion
    }
}