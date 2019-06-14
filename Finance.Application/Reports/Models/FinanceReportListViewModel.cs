using System.Collections.Generic;

namespace Finance.Application.Reports.Models
{
    public class FinanceReportListViewModel
    {
        public IEnumerable<FinanceReportViewModel> FinanceReportViewModels { get; set; }
    }
}