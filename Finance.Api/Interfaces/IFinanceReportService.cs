using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Client.Interfaces
{
    public interface IFinanceReportService
    {
        IEnumerable<object> GetAllFinanceReports();
    }
}
