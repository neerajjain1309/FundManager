using System;
using FundManager.Domain.Interfaces;

namespace FundManager.Domain
{
    public class InstrumentFactory : IInstrumentFactory
    {
        public IInstrument CreateInstrument(IInstrumentInfo instrumentInfo, int instrumentCounter)
        {
            if (instrumentInfo.InstrumentType == InstrumentType.Bond)
            {
                return new Bond(instrumentCounter, instrumentInfo.Quantity, instrumentInfo.Price);
            }
            if (instrumentInfo.InstrumentType == InstrumentType.Equity)
            {
                return new Equity(instrumentCounter, instrumentInfo.Quantity, instrumentInfo.Price);
            }
            throw new Exception("Invalid Instrument type.");
        }
    }
}