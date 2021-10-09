using System;
using System.Globalization;
using System.Windows.Data;
using FundManager.Domain.Interfaces;

namespace FundManager.Infrastructure.Converters
{
    public class StockToColorConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stock = value as IInstrument;
            if (stock == null)
                return null;

            //Market Value is < 0 or Transaction Cost > Tolerance
            return stock.MarketValue < 0m || stock.TransactionCost > stock.Tolerance ? "#ffff0000" : "#ff00cc00";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

        #endregion
    }
}