using FundManager.Infrastructure.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Data;

namespace FundManager.Infrastructure.Tests.Converters
{
    [TestClass]
    public class CurrencyConverterTests
    {
        [TestMethod]
        public void ShouldConvertDecimalToCurrency()
        {
            var converter = new CurrencyConverter();
            decimal? numDecimal = 20;

            var convertedValue = converter.Convert(numDecimal, typeof(decimal?), null, null) as string;

            Assert.AreEqual("$20.00", convertedValue);

            convertedValue = converter.Convert(null, null, null, null) as string;

            Assert.AreEqual("$0.00", convertedValue);
        }

        [TestMethod]
        public void ShouldReturnDoNothingInConvertBack()
        {
            var converter = new CurrencyConverter();
            var convertedValue = converter.ConvertBack(null, null, null, null);
            Assert.AreEqual(Binding.DoNothing, convertedValue);
        }
    }
}