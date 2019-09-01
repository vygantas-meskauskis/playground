using Finance.Application.Analytics.Models;
using MediatR;
using System.Collections.Generic;

namespace Finance.Application.Analytics.Queries
{
    public class GetCategorizedTransactionsQuery : IRequest<IEnumerable<CategorizedFinanceTransactionsViewModel>>
    {
        public GetCategorizedTransactionsQuery(List<string> sources)
        {
            Sources = sources;
        }
        public List<string> Sources { get; set; }
    }
}
