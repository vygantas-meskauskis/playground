using System.Collections.Generic;
using System.Linq;
using Finance.Application.Interfaces;
using Finance.Domain.Entitites;
using Microsoft.Extensions.Caching.Memory;

namespace Finance.Persistence
{
    public class FinanceReportMemoryContext : IFinanceDataContext
    {
        private readonly IMemoryCache _memoryCache;
        public FinanceReportMemoryContext(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public List<FinanceReport> FinanceReports
        {
            get => _memoryCache.Get<List<FinanceReport>>("finance-reports") ?? new List<FinanceReport>();
            set => _memoryCache.Set("finance-reports", value);
        }

        public void AddFinanceReport(FinanceReport financeReport)
        {
            var reports = _memoryCache.Get<List<FinanceReport>>("finance-reports");
            reports.Add(financeReport);
            _memoryCache.Set("finance-reports", reports);
        }
    }

}
