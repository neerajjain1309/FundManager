using FundManager.Domain.Interfaces;

namespace FundManager.Domain
{
    public class InstrumentInfo : IInstrumentInfo
    {
        public InstrumentInfo(InstrumentType instrumentType, int quantity, decimal price)
        {
            InstrumentType = instrumentType;
            Quantity = quantity;
            Price = price;
        }

        public InstrumentType InstrumentType { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}