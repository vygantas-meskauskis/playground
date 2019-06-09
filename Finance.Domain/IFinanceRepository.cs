using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain
{
    public interface IFinanceRepository
    {
        Task<FinanceReport> GetFinanceReportAsync(string reportId);
        Task<List<FinanceReport>> GetAllFinanceReportsAsync();
    }
}
