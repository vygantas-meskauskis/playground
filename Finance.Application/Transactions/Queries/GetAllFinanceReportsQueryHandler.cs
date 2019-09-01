using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Finance.Application.Reports.Models;
using Finance.Application.Reports.Queries;
using Finance.Domain.Interfaces;
using MediatR;

namespace Finance.Application.Transactions.Queries
{
    public class GetAllFinanceReportsQueryHandler : IRequestHandler<GetAllFinanceReportsQuery, FinanceTransactionsListViewModel>
    {
        private readonly IFinanceRepository _financeRepository;

        public GetAllFinanceReportsQueryHandler(IFinanceRepository financeRepository)
        {
            _financeRepository = financeRepository;
        }

        public async Task<FinanceTransactionsListViewModel> Handle(GetAllFinanceReportsQuery request, CancellationToken cancellationToken)
        {
            var financeReports = await _financeRepository.GetAllFinanceReportsAsync();
            var reportsListViewModel = new FinanceTransactionsListViewModel
            {
                FinanceReportViewModels = financeReports.Select(FinanceReportViewModel.Create)
            };

            return reportsListViewModel;
        }
    }
}