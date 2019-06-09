using Finance.Domain;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Infrastructure
{
    public class FinanceReportMemoryContext
    {
        private readonly IMemoryCache _memoryCache;
        public FinanceReportMemoryContext(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<List<FinanceReport>> FinanceReports
        {
            get
            {
                return  Task.FromResult(_memoryCache.Get<List<FinanceReport>>("finance-reports"));
            }
            set
            {
                _memoryCache.Set("finance-reports", value);
            }
        }

        public void AddFinanceReport(FinanceReport financeReport)
        {
            var reports = _memoryCache.Get<List<FinanceReport>>("finance-reports");
            reports.Add(financeReport);
            _memoryCache.Set("finance-reports", reports);
        }
    }
}
