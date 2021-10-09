namespace FundManager.Domain
{
    public class AllInstrumentsSummary : InstrumentSummary
    {
        public AllInstrumentsSummary(int totalNumber, decimal totalStockWeight, decimal totalMarketValue)
            : base(totalNumber, totalStockWeight, totalMarketValue, InstrumentType.All)
        {
        }

    }
}