using System.Linq;
using System.Reflection;
using FundManager.Domain.Interfaces;

namespace FundManager.Domain
{
    public class EquitySummary : InstrumentSummary
    {
        public EquitySummary(int totalNumber, decimal totalStockWeight, decimal totalMarketValue)
            : base(totalNumber, totalStockWeight, totalMarketValue, InstrumentType.Equity)
        {
        }
    }
}