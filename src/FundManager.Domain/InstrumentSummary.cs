using FundManager.Domain.Interfaces;

namespace FundManager.Domain
{
    public abstract class InstrumentSummary : IInstrumentSummary
    {
        public int TotalNumber { get; private set; }
        public decimal TotalWeight { get; private set; }
        public decimal TotalMarketValue { get; private set; }

        public InstrumentType InstrumentType { get; private set; }

        protected InstrumentSummary(int totalNumber, decimal totalStockWeight, decimal totalMarketValue,
            InstrumentType instrumentType)
        {
            TotalNumber = totalNumber;
            TotalWeight = totalStockWeight;
            TotalMarketValue = totalMarketValue;
            InstrumentType = instrumentType;
        }
    }
}