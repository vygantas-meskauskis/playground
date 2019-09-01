using Finance.Client.Interfaces;
using System.IO;
using Finance.Application.Reports.Commands;
using MediatR;
using Finance.Application.Reports.Queries;
using System.Threading.Tasks;
using Finance.Application.Reports.Models;
using Finance.Application.Analytics.Models;
using System.Collections.Generic;
using Finance.Application.Analytics.Queries;

namespace Finance.Client.Services
{
    public class FinanceReportService : IFinanceReportService
    {
        private readonly IMediator _mediator;

        public FinanceReportService(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        public async Task<FinanceTransactionsListViewModel> GetAllFinanceReports()
        {
            return await _mediator.Send(new GetAllFinanceReportsQuery());
        }

        public async Task<IEnumerable<CategorizedFinanceTransactionsViewModel>> GetCategorizedFinanceTransactions(List<string> sources)
        {
            return await _mediator.Send(new GetCategorizedTransactionsQuery(sources));
        }

        public async Task UploadFileAsync(string fileSource, Stream file)
        {
            await _mediator.Send(new UploadFileCommand
            {
                FileSource = fileSource,
                FileStream = file
            });
        }
    }
}
