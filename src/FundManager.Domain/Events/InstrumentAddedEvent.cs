using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundManager.Domain.Interfaces;
using Microsoft.Practices.Prism.PubSubEvents;

namespace FundManager.Domain.Events
{
    public class InstrumentAddedEvent : PubSubEvent<IInstrumentInfo>
    {
    }
}
