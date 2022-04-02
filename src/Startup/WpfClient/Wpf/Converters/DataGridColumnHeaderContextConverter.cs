using System;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfClient.Wpf.Converters
{
    internal class DataGridColumnHeaderContextConverter : MarkupExtension, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2 && values[0] is DataGrid grid && values[1] is string columnHeader)
            {
                var column = grid.Columns.FirstOrDefault(x => x.Header == columnHeader);

                if (column != null)
                {
                    return column;
                }
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}