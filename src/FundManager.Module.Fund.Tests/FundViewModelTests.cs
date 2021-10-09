using System;
using System.Linq;
using FundManager.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FundManager.Domain.Events;
using FundManager.Domain.Interfaces;
using FundManager.Module.Fund.ViewModels;
using Microsoft.Practices.Prism.PubSubEvents;
using Moq;

namespace FundManager.Module.Fund.Tests
{
    [TestClass]
    public class FundViewModelTests
    {
        [TestMethod]
        public void ShouldInsertInstrument()
        {
            var instrumentAddedEvent = new InstrumentAddedEvent();
            var stocksSummaryUpdatedEvent = new StocksSummaryUpdatedEvent();
            var eventAggregator = new Mock<IEventAggregator>();
            eventAggregator.Setup(x => x.GetEvent<InstrumentAddedEvent>()).Returns(instrumentAddedEvent);
            eventAggregator.Setup(x => x.GetEvent<StocksSummaryUpdatedEvent>()).Returns(stocksSummaryUpdatedEvent);

            var stock = new Bond(1, 100, 500m);
            var instInfo = new InstrumentInfo(InstrumentType.Bond, 100, 500m);
            var instrumentFactory = new Mock<IInstrumentFactory>();
            instrumentFactory.Setup(x => x.CreateInstrument(instInfo, 1)).Returns(stock);

            var viewModel = new FundViewModel(eventAggregator.Object, instrumentFactory.Object);
            eventAggregator.Object.GetEvent<InstrumentAddedEvent>().Publish(instInfo);
            Assert.IsTrue(viewModel.StockItems.Count == 1);
            Assert.AreEqual(viewModel.StockItems[0], stock);

        }

        [TestMethod]
        public void ShouldUpdateStockWeight()
        {
            var instrumentAddedEvent = new InstrumentAddedEvent();
            var stocksSummaryUpdatedEvent = new StocksSummaryUpdatedEvent();
            var eventAggregator = new Mock<IEventAggregator>();
            eventAggregator.Setup(x => x.GetEvent<InstrumentAddedEvent>()).Returns(instrumentAddedEvent);
            eventAggregator.Setup(x => x.GetEvent<StocksSummaryUpdatedEvent>()).Returns(stocksSummaryUpdatedEvent);

            var stock1 = new Bond(1, 100, 500m);
            var instInfo1 = new InstrumentInfo(InstrumentType.Bond, 100, 500m);
            var stock2 = new Equity(1, 200, 100m);
            var instInfo2 = new InstrumentInfo(InstrumentType.Equity, 200, 100m);

            var instrumentFactory = new Mock<IInstrumentFactory>();
            instrumentFactory.Setup(x => x.CreateInstrument(instInfo1, 1)).Returns(stock1);
            instrumentFactory.Setup(x => x.CreateInstrument(instInfo2, 1)).Returns(stock2);

            var viewModel = new FundViewModel(eventAggregator.Object, instrumentFactory.Object);

            eventAggregator.Object.GetEvent<InstrumentAddedEvent>().Publish(instInfo1);
            Assert.IsTrue(viewModel.StockItems.Count == 1);
            var calculatedStockWeight1 = (viewModel.StockItems[0].MarketValue * 100) /
                                        viewModel.StockItems.Sum(x => x.MarketValue);
            Assert.AreEqual(viewModel.StockItems[0].StockWeight, calculatedStockWeight1);


            eventAggregator.Object.GetEvent<InstrumentAddedEvent>().Publish(instInfo2);
            Assert.IsTrue(viewModel.StockItems.Count == 2);
            var calculatedStockWeight2 = (viewModel.StockItems[1].MarketValue * 100) /
                                        viewModel.StockItems.Sum(x => x.MarketValue);

            Assert.AreEqual(viewModel.StockItems[1].StockWeight, calculatedStockWeight2);
        }
    }
}
