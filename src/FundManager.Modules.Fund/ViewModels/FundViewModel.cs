using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundManager.Domain;
using FundManager.Domain.Events;
using FundManager.Domain.Interfaces;
using Microsoft.Practices.Prism.PubSubEvents;

namespace FundManager.Module.Fund.ViewModels
{
    public class FundViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IInstrumentFactory _instrumentFactory;
        private readonly ObservableCollection<IInstrument> _stockItems;

        public FundViewModel(IEventAggregator eventAggregator, IInstrumentFactory instrumentFactory)
        {
            _eventAggregator = eventAggregator;
            _instrumentFactory = instrumentFactory;
            _stockItems = new ObservableCollection<IInstrument>();
            _eventAggregator.GetEvent<InstrumentAddedEvent>().Subscribe(AddInstrument, true);
        }

        private void AddInstrument(IInstrumentInfo info)
        {
            var count = _stockItems.Count(i => i.InstrumentType == info.InstrumentType);
            var instrument = _instrumentFactory.CreateInstrument(info, count + 1);
            _stockItems.Add(instrument);
            UpdateStockWeight();
            UpdateStocksSummary();
        }

        private void UpdateStockWeight()
        {
            var totalMktValue = _stockItems.Sum(x => x.MarketValue);
            foreach (var stock in _stockItems)
                stock.StockWeight = (stock.MarketValue * 100) / totalMktValue;
        }

        private void UpdateStocksSummary()
        {
            _eventAggregator.GetEvent<StocksSummaryUpdatedEvent>().Publish(_stockItems.ToList());
        }

        public ObservableCollection<IInstrument> StockItems
        {
            get { return _stockItems; }
        }
    }

}
