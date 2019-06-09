using Finance.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finance.Infrastructure
{
    public class FinanceRepository : IFinanceRepository
    {
        private readonly FinanceReportMemoryContext _context;

        public FinanceRepository(FinanceReportMemoryContext context)
        {
            _context = context;
        }
        public Task<List<FinanceReport>> GetAllFinanceReportsAsync()
        {
            return _context.FinanceReports;
        }

        public Task<FinanceReport> GetFinanceReportAsync(string reportId)
        {
            throw new NotImplementedException();
        }
    }
}
