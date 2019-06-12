using System.Collections.Generic;
using System.IO;

namespace Finance.Client.Interfaces
{
    public interface IFinanceReportService
    {
        IEnumerable<object> GetAllFinanceReports();
        void UploadFile(string fileSource, Stream file);
    }
}
