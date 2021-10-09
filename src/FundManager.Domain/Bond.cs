namespace FundManager.Domain
{
    public class Bond : Instrument
    {
        public Bond(int instrumentCounter, int quantity, decimal price)
            : base(InstrumentType.Bond, instrumentCounter, quantity, price)
        {
        }

        public override decimal TransactionCost
        {
            get { return MarketValue * (2m / 100); }
        }

        public override decimal Tolerance
        {
            get { return 100000m; }
        }
    }
}