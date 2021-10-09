using FundManager.Domain;
using FundManager.Domain.Interfaces;
using FundManager.Infrastructure.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FundManager.Infrastructure.Tests.Converters
{
    [TestClass]
    public class StockToColorConverterTests
    {
        [TestMethod]
        public void ShouldConvertStockNameToColor()
        {
            var converter = new StockToColorConverter();
            var stock = new Bond(1, 10000, 2000m);

            var convertedValue = converter.Convert(stock, typeof(IInstrument), null, null) as string;

            Assert.AreEqual("#ffff0000", convertedValue);

            var stock2 = new Equity(1, 10000, 2000m);
            convertedValue = converter.Convert(stock2, typeof(IInstrument), null, null) as string;
            Assert.AreNotEqual("#ffff0000", convertedValue);
        }

        [TestMethod]
        public void ShouldReturnDoNothingInConvertBack()
        {
            var converter = new StockToColorConverter();

            var convertedValue = converter.ConvertBack(null, null, null, null);
        }
    }
}