using System.Windows;
using System.Windows.Data;
using FundManager.Infrastructure.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FundManager.Infrastructure.Tests.Converters
{
    [TestClass]
    public class InvertedBooleanToVisibilityConverterTests
    {
        [TestMethod]
        public void ShouldConvertInvertedBooleanToVisibility()
        {
            var converter = new InvertedBooleanToVisibilityConverter();
            bool b1 = true;
            bool b2 = false;

            var convertedValue = converter.Convert(b1, typeof(bool?), null, null);
            Assert.AreEqual(Visibility.Collapsed, convertedValue);
            convertedValue = converter.Convert(b2, typeof(bool?), null, null);
            Assert.AreEqual(Visibility.Visible, convertedValue);

        }

        [TestMethod]
        public void ShouldReturnDoNothingInConvertBack()
        {
            var converter = new BooleanToVisibilityConverter();
            var convertedValue = converter.ConvertBack(null, null, null, null);
            Assert.AreEqual(Binding.DoNothing, convertedValue);
        }
    }
}