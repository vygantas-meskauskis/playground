using System.Collections.Generic;
using Finance.Domain.Entitites;

namespace Finance.Application.Interfaces
{
    public interface IFinanceDataContext
    {
        List<FinanceReport> FinanceReports { get; set; }
    }
}
