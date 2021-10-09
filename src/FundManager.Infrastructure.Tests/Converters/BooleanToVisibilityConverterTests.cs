using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundManager.Infrastructure.Converters;
using System.Windows;
using System.Windows.Data;

namespace FundManager.Infrastructure.Tests.Converters
{
    [TestClass]
    public class BooleanToVisibilityConverterTests
    {
        [TestMethod]
        public void ShouldConvertBooleanToVisibility()
        {
            var converter = new BooleanToVisibilityConverter();
            bool b1 = true;
            bool b2 = false;

            var convertedValue = converter.Convert(b1, typeof(bool?), null, null);

            Assert.AreEqual(Visibility.Visible, convertedValue);

            convertedValue = converter.Convert(b2, typeof(bool?), null, null);
            Assert.AreEqual(Visibility.Collapsed, convertedValue);

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
