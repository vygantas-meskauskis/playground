using Finance.Application.Reports.Queries;
using System.IO;
using System.Threading.Tasks;
using Finance.Application.Reports.Models;
using Finance.Application.Analytics.Models;
using System.Collections.Generic;

namespace Finance.Client.Interfaces
{
    public interface IFinanceReportService
    {
        Task<FinanceTransactionsListViewModel> GetAllFinanceReports();
        Task UploadFileAsync(string fileSource, Stream file);
        Task<IEnumerable<CategorizedFinanceTransactionsViewModel>> GetCategorizedFinanceTransactions(List<string> sources);
    }
}
