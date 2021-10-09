namespace FundManager.Domain.Interfaces
{
    public interface IInstrumentInfo
    {
        InstrumentType InstrumentType { get; }
        int Quantity { get; }
        decimal Price { get; }
    }
    public interface IInstrument : IInstrumentInfo
    {
        string InstrumentName { get; }
        decimal MarketValue { get; }
        decimal TransactionCost { get; }
        decimal Tolerance { get; }
        decimal StockWeight { get; set; }

    }
}