using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfClient.Wpf.Converters
{
    public class EmptyOrWhitespaceStringToBool : MarkupExtension, IValueConverter
    {
        public bool IsFalseIfEmpty { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return IsFalseIfEmpty;
            }

            if (value is string str)
            {
                var isEmpty = string.IsNullOrWhiteSpace(str);

                return IsFalseIfEmpty ? isEmpty : !isEmpty;
            }

            return !IsFalseIfEmpty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}