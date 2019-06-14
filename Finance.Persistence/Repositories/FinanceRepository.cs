using System.Collections.Generic;
using System.Linq;
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

        public void Add(FinanceReport financeReport)
        {
            _context.FinanceReports.Add(financeReport);
            var financeReports = _context.FinanceReports;
            financeReports.Add(financeReport);
            _context.FinanceReports = financeReports;
        }

        public void Update(FinanceReport financeReport)
        {
            var report = _context.FinanceReports.FirstOrDefault(x => financeReport.GuidId.Equals(x.GuidId));
            _context.FinanceReports.Remove(report);
            _context.FinanceReports.Add(financeReport);
        }

        public Task<FinanceReport> GetFinanceReportBySourceAsync(string source)
        {
            return Task.FromResult(_context.FinanceReports.FirstOrDefault(x => x.IsSourceOf(source)));
        }

        public Task<List<FinanceReport>> GetAllFinanceReportsAsync()
        {
            return Task.FromResult(_context.FinanceReports);
        }
    }
}
