using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Finance.Domain.Entitites;
using Finance.Domain.Interfaces;

namespace Finance.Persistence.Repositories
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
            return Task.FromResult(_context.FinanceReports);
        }

        public Task<FinanceReport> GetFinanceReportAsync(string reportId)
        {
            throw new NotImplementedException();
        }
    }
}
