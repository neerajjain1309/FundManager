namespace FundManager.Domain.Interfaces
{
    public interface IInstrumentFactory
    {
        IInstrument CreateInstrument(IInstrumentInfo instrumentInfo, int instrumentCounter);
    }
}