using System.Collections.Generic;
using System.Threading.Tasks;
using Finance.Domain.Entitites;

namespace Finance.Domain.Interfaces
{
    public interface IFinanceRepository
    {
        void Add(FinanceReport financeReport);
        void Update(FinanceReport financeReport);
        Task<FinanceReport> GetFinanceReportBySourceAsync(string source);
        Task<List<FinanceReport>> GetAllFinanceReportsAsync();
    }
}
