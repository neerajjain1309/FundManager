using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FundManager.Infrastructure.Converters
{
    public class InvertedBooleanToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            var result = System.Convert.ToBoolean(value);
            return result ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

        #endregion
    }
}