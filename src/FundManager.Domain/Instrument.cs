using FundManager.Domain.Interfaces;

namespace FundManager.Domain
{
    public abstract class Instrument : NotifyPropertyChanged, IInstrument
    {
        private decimal _stockWeight;
        public Instrument(InstrumentType instrumentType, int instrumentCounter, int quantity, decimal price)
        {
            InstrumentType = instrumentType;
            Quantity = quantity;
            Price = price;
            InstrumentName = string.Format("{0}{1}", instrumentType, instrumentCounter);
        }

        public InstrumentType InstrumentType { get; private set; }
        public string InstrumentName { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public decimal MarketValue
        {
            get { return Price * Quantity; }
        }

        public abstract decimal TransactionCost { get; }

        public decimal StockWeight
        {
            get { return _stockWeight; }
            set { _stockWeight = value; OnPropertyChanged("StockWeight"); }
        }

        public virtual decimal Tolerance
        {
            get { return 100000m; }
        }
    }
}