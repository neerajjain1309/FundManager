using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundManager.Domain;
using FundManager.Domain.Events;
using FundManager.Module.AddInstrument.ViewModels;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FundManager.Module.AddInstrument.Tests
{
    [TestClass]
    public class AddInstrumentViewModelTests
    {
        [TestMethod]
        public void ShouldNotAddInstrumentWithInvalidPrice()
        {
            var instrumentAddedEvent = new InstrumentAddedEvent();
            var mockEventAggregator = new Mock<IEventAggregator>();
            mockEventAggregator.Setup(x => x.GetEvent<InstrumentAddedEvent>()).Returns(instrumentAddedEvent);

            var viewModel = new AddInstrumentViewModel(mockEventAggregator.Object)
            {
                SelectedInstrumentType = InstrumentType.Bond,
                InstrumentPrice = "abc",
                InstrumentQuantity = "100"
            };

            Assert.IsFalse(viewModel.AddInstrumentCommand.CanExecute());

        }

        [TestMethod]
        public void ShouldNotAddInstrumentWithInvalidQuantity()
        {
            var instrumentAddedEvent = new InstrumentAddedEvent();
            var mockEventAggregator = new Mock<IEventAggregator>();
            mockEventAggregator.Setup(x => x.GetEvent<InstrumentAddedEvent>()).Returns(instrumentAddedEvent);

            var viewModel = new AddInstrumentViewModel(mockEventAggregator.Object)
            {
                SelectedInstrumentType = InstrumentType.Bond,
                InstrumentPrice = "100.55",
                InstrumentQuantity = "0"
            };

            Assert.IsFalse(viewModel.AddInstrumentCommand.CanExecute());
        }

        [TestMethod]
        public void ShouldAddInstrument()
        {
            var instrumentAddedEvent = new InstrumentAddedEvent();
            var mockEventAggregator = new Mock<IEventAggregator>();
            mockEventAggregator.Setup(x => x.GetEvent<InstrumentAddedEvent>()).Returns(instrumentAddedEvent);

            var viewModel = new AddInstrumentViewModel(mockEventAggregator.Object)
            {
                SelectedInstrumentType = InstrumentType.Bond,
                InstrumentPrice = "100.56",
                InstrumentQuantity = "1000"
            };

            Assert.IsTrue(viewModel.AddInstrumentCommand.CanExecute());

        }
    }
}
