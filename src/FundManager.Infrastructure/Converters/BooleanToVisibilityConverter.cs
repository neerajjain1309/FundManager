using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FundManager.Infrastructure.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            var result = System.Convert.ToBoolean(value);
            return result ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

        #endregion
    }
}