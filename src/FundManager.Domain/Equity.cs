namespace FundManager.Domain
{
    public class Equity : Instrument
    {
        public Equity(int instrumentCounter, int quantity, decimal price)
            : base(InstrumentType.Equity, instrumentCounter, quantity, price)
        {
        }

        public override decimal TransactionCost
        {
            get { return MarketValue * (0.5m / 100); }
        }

        public override decimal Tolerance
        {
            get { return 200000m; }
        }
    }
}