using Finance.Application.Reports.Models;
using MediatR;

namespace Finance.Application.Reports.Queries
{
    public class GetAllFinanceReportsQuery : IRequest<FinanceTransactionsListViewModel>
    {
    }
}
