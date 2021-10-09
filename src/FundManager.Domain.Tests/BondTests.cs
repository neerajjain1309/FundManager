using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FundManager.Domain.Tests
{
    [TestClass]
    public class BondTests
    {
        [TestMethod]
        public void TransactionCostShouldBeTwoPercentOfMarketValue()
        {
            var stock = new Bond(1, 1000, 5m);
            var trnsCost = stock.MarketValue * 0.02m;
            Assert.AreEqual(trnsCost, stock.TransactionCost);

        }
    }
}