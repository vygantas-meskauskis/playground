using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Finance.Domain.Entitites;
using Finance.Domain.Interfaces;
using MediatR;

namespace Finance.Application.Reports.Queries
{
    public class GetAllFinanceReportsQuery : IRequest<FinanceReportListViewModel>
    {
    }

    public class GetAllFinanceReportsQueryHandler : IRequestHandler<GetAllFinanceReportsQuery, FinanceReportListViewModel>
    {
        private readonly IFinanceRepository _financeRepository;

        public GetAllFinanceReportsQueryHandler(IFinanceRepository financeRepository)
        {
            _financeRepository = financeRepository;
        }

        public async Task<FinanceReportListViewModel> Handle(GetAllFinanceReportsQuery request, CancellationToken cancellationToken)
        {
            var financeReports = await _financeRepository.GetAllFinanceReportsAsync();
            var reportsListViewModel = new FinanceReportListViewModel
            {
                FinanceReportViewModels = financeReports.Select(FinanceReportViewModel.Create)
            };

            return reportsListViewModel;
        }
    }

    public class FinanceReportListViewModel
    {
        public IEnumerable<FinanceReportViewModel> FinanceReportViewModels { get; set; }
    }

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

    public class FinanceRecordViewModel
    {
        public string Category { get; set; }
        public double TransferAmount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        public static Expression<Func<FinanceRecord, FinanceRecordViewModel>> Projection
        {
            get
            {
                return financeRecord => new FinanceRecordViewModel
                {
                    TransferAmount = financeRecord.TransferAmount,
                    Category = financeRecord.Category,
                    Date = financeRecord.Date,
                    Description = financeRecord.Description,
                    Notes = financeRecord.Notes
                };
            }
        }

        public static FinanceRecordViewModel Create(FinanceRecord financeRecord)
        {
            return Projection.Compile().Invoke(financeRecord);
        }
    }
}
