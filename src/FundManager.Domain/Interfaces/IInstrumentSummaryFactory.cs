namespace FundManager.Domain.Interfaces
{
    public interface IInstrumentSummaryFactory
    {
        IInstrumentSummary CreateInstrumentSummary(InstrumentType instrumentType, int totalNumberOfStocks, decimal totalStockWeight, decimal totalMktValue);
    }
}