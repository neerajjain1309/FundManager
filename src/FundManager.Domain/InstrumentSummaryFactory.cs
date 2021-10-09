using System;
using FundManager.Domain.Interfaces;

namespace FundManager.Domain
{
    public class InstrumentSummaryFactory : IInstrumentSummaryFactory
    {
        public IInstrumentSummary CreateInstrumentSummary(InstrumentType instrumentType, int totalNumberOfStocks,
            decimal totalStockWeight, decimal totalMktValue)
        {
            if (instrumentType == InstrumentType.Bond)
            {
                return new BondSummary(totalNumberOfStocks, totalStockWeight, totalMktValue);
            }
            if (instrumentType == InstrumentType.Equity)
            {
                return new EquitySummary(totalNumberOfStocks, totalStockWeight, totalMktValue);
            }
            if (instrumentType == InstrumentType.All)
            {
                return new AllInstrumentsSummary(totalNumberOfStocks, totalStockWeight, totalMktValue);
            }
            throw new Exception("Invalid Instrument type.");
        }
    }
}