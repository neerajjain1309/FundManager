namespace FundManager.Domain
{
    public class BondSummary : InstrumentSummary
    {
        public BondSummary(int totalNumber, decimal totalStockWeight, decimal totalMarketValue)
            : base(totalNumber, totalStockWeight, totalMarketValue, InstrumentType.Bond)
        {
        }
    }
}