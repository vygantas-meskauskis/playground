using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Finance.Domain.Entitites;

namespace Finance.Application.Reports.Models
{
    public class FinanceReportViewModel
    {
        public string Source { get; set; }
        public string Currency { get; set; }
        public string GuidId { get; set; }
        public IEnumerable<FinanceRecordViewModel> FinanceRecordViewModels { get; set; }

        public static Expression<Func<FinanceReport, FinanceReportViewModel>> Projection
        {
            get
            {
                return customer => new FinanceReportViewModel
                {
                    GuidId = customer.GuidId,
                    Currency = customer.Currency,
                    Source = customer.Source,
                    FinanceRecordViewModels = customer.FinanceRecords.Select(FinanceRecordViewModel.Create)
                };
            }
        }

        public static FinanceReportViewModel Create(FinanceReport financeReport)
        {
            return Projection.Compile().Invoke(financeReport);
        }
    }
}