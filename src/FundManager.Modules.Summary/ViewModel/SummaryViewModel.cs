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

namespace FundManager.Module.Summary.ViewModel
{
    public class SummaryViewModel
    {
        private readonly IInstrumentSummaryFactory _instrumentSummaryFactory;
        private readonly ObservableCollection<InstrumentSummaryViewModel> _instrumentSummarySource;


        public SummaryViewModel(IEventAggregator eventAggregator, IInstrumentSummaryFactory instrumentSummaryFactory)
        {
            _instrumentSummaryFactory = instrumentSummaryFactory;
            _instrumentSummarySource = new ObservableCollection<InstrumentSummaryViewModel>();
            eventAggregator.GetEvent<StocksSummaryUpdatedEvent>().Subscribe(UpdateSummary, true);

        }

        private void UpdateSummary(IEnumerable<IInstrument> instruments)
        {
            _instrumentSummarySource.Clear();
            var totalMktValueFund = instruments.Sum(x => x.MarketValue);
            var instrumentTypes = Enum.GetValues(typeof(InstrumentType)).Cast<InstrumentType>();
            foreach (var instType in instrumentTypes)
            {
                var summary = GetInstrumentSummary(instruments.ToList(), totalMktValueFund, instType);
                _instrumentSummarySource.Add(new InstrumentSummaryViewModel(summary));

            }
        }

        private IInstrumentSummary GetInstrumentSummary(List<IInstrument> instruments, decimal totalMktValueFund, InstrumentType instrumentType)
        {
            var stocks = instrumentType == InstrumentType.All
                ? instruments
                : instruments.Where(x => x.InstrumentType == instrumentType).ToList();
            var numberOfStocks = stocks.Sum(x => x.Quantity);
            var stocksMktValue = stocks.Sum(x => x.MarketValue);
            var stocksWeight = (stocksMktValue * 100) / totalMktValueFund;
            return _instrumentSummaryFactory.CreateInstrumentSummary(instrumentType, numberOfStocks, stocksWeight,
                stocksMktValue);

        }

        public ObservableCollection<InstrumentSummaryViewModel> InstrumentSummarySource
        {
            get { return _instrumentSummarySource; }
        }
    }
}
