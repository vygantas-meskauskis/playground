using Finance.Application.Reports.Queries;
using System.IO;
using System.Threading.Tasks;

namespace Finance.Client.Interfaces
{
    public interface IFinanceReportService
    {
        Task<FinanceReportListViewModel> GetAllFinanceReports();
        Task UploadFileAsync(string fileSource, Stream file);
    }
}
