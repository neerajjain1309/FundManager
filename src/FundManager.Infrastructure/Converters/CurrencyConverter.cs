using System.Globalization;
using System.Windows.Data;

namespace FundManager.Infrastructure.Converters
{
    public class CurrencyConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            var result = value as decimal?;

            if (result == null)
                result = 0;

            return string.Format(CultureInfo.CurrentUICulture, "{0:C}", result.Value);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

        #endregion
    }
}