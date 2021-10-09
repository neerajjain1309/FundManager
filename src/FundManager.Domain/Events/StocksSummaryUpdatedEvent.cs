using System.Collections.Generic;
using FundManager.Domain.Interfaces;
using Microsoft.Practices.Prism.PubSubEvents;

namespace FundManager.Domain.Events
{
    public class StocksSummaryUpdatedEvent : PubSubEvent<IEnumerable<IInstrument>>
    {
    }
}