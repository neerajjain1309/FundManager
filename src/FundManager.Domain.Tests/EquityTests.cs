using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FundManager.Domain.Tests
{
    [TestClass]
    public class EquityTests
    {
        [TestMethod]
        public void TransactionCostShouldBePointFivePercentOfMarketValue()
        {
            var stock = new Equity(1, 1000, 5m);
            var trnsCost = stock.MarketValue * 0.005m;
            Assert.AreEqual(trnsCost, stock.TransactionCost);

        }
    }
}
