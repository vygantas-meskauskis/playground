using Finance.Application.Analytics.Models;
using Finance.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Finance.Application.Analytics.Queries
{
    public class GetCategorizedTransactionsQueryHandler : IRequestHandler<GetCategorizedTransactionsQuery, IEnumerable<CategorizedFinanceTransactionsViewModel>>
    {
        private readonly IFinanceRepository _financeRepository;

        public GetCategorizedTransactionsQueryHandler(IFinanceRepository financeRepository)
        {
            _financeRepository = financeRepository;
        }

        public async Task<IEnumerable<CategorizedFinanceTransactionsViewModel>> Handle(GetCategorizedTransactionsQuery request, CancellationToken cancellationToken)
        {
            var financeTransactions =  await Task.WhenAll(request.Sources.Select(x => _financeRepository.GetFinanceReportBySourceAsync(x)));
            var allMoneySpent = financeTransactions.Select(x => x.GetTransferedOutMoneySum()).Sum();

            var groupedTransactions = financeTransactions
                .SelectMany(x => x.FinanceRecords)
                .GroupBy(x => x.Category)
                .ToDictionary(x => x.Key, x => x.ToList());

            var categorizedTransactions = new List<CategorizedFinanceTransactionsViewModel>();
            foreach(var transactions in groupedTransactions)
            {
                categorizedTransactions.Add(new CategorizedFinanceTransactionsViewModel
                {
                    Category = transactions.Key,
                    Amount = transactions.Value.Where(x => x.TransferAmount < 0).Sum(f => f.TransferAmount).ToString() + " €",
                    NumberOfTransactions = transactions.Value.Count(),
                    Percentage = string.Format("{0:N} %", ((transactions.Value.Sum(f => f.TransferAmount) * 100) / allMoneySpent))
                });
            }

            return categorizedTransactions;
        }
    }
}
