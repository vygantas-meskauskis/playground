using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Finance.Application.Reports.Models;
using Finance.Domain.Interfaces;
using MediatR;

namespace Finance.Application.Reports.Queries
{
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
}