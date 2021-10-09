using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace FundManager.Infrastructure.Converters
{
    public class PercentConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            var result = value as decimal?;
            if (result == null)
                result = 0;

            return string.Format(CultureInfo.CurrentUICulture, "{0:F1}%", result.Value);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

        #endregion
    }
}

