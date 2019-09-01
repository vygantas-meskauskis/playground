using System.Collections.Generic;

namespace Finance.Application.Reports.Models
{
    public class FinanceTransactionsListViewModel
    {
        public IEnumerable<FinanceReportViewModel> FinanceReportViewModels { get; set; }
    }
}