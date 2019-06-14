using Finance.Application.Reports.Queries;
using System.IO;
using System.Threading.Tasks;
using Finance.Application.Reports.Models;

namespace Finance.Client.Interfaces
{
    public interface IFinanceReportService
    {
        Task<FinanceReportListViewModel> GetAllFinanceReports();
        Task UploadFileAsync(string fileSource, Stream file);
    }
}
