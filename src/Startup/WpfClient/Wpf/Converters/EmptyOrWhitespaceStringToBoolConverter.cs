using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfClient.Wpf.Converters
{
    public class EmptyOrWhitespaceStringToBoolConverter : MarkupExtension, IValueConverter
    {
        /// <summary>
        ///     Value that returns if the entry is an empty or whitespace string, or null.
        /// </summary>
        public bool ReturnValueForEmpty { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return ReturnValueForEmpty;
            }

            if (value is string str)
            {
                return string.IsNullOrWhiteSpace(str) ? ReturnValueForEmpty : !ReturnValueForEmpty;
            }

            throw new ArgumentException(nameof(value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}