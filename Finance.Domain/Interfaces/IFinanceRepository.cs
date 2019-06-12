using System.Collections.Generic;
using System.Threading.Tasks;
using Finance.Domain.Entitites;

namespace Finance.Domain.Interfaces
{
    public interface IFinanceRepository
    {
        FinanceReport Add(FinanceReport financeReport);
        Task<FinanceReport> GetFinanceReportAsync(string reportId);
        Task<List<FinanceReport>> GetAllFinanceReportsAsync();
    }
}
