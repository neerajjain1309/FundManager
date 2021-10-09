using FundManager.Infrastructure.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FundManager.Infrastructure.Tests.Converters
{
    [TestClass]
    public class PercentConverterTests
    {
        [TestMethod]
        public void ShouldConvertDecimalToPercent()
        {
            var converter = new PercentConverter();
            decimal? numDecimal = 20;

            var convertedValue = converter.Convert(numDecimal, typeof(decimal?), null, null) as string;

            Assert.AreEqual("20.0%", convertedValue);

            convertedValue = converter.Convert(null, null, null, null) as string;

            Assert.AreEqual("0.0%", convertedValue);
        }

        [TestMethod]
        public void ShouldReturnDoNothingInConvertBack()
        {
            var converter = new PercentConverter();

            var convertedValue = converter.ConvertBack(null, null, null, null);
        }
    }
}