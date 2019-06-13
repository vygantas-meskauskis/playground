using Finance.Client.Interfaces;
using System.IO;
using Finance.Application.Reports.Commands;
using MediatR;
using Finance.Application.Reports.Queries;
using System.Threading.Tasks;

namespace Finance.Client.Services
{
    public class FinanceReportService : IFinanceReportService
    {
        private readonly IMediator _mediator;

        public FinanceReportService(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        public async Task<FinanceReportListViewModel> GetAllFinanceReports()
        {
            return await _mediator.Send(new GetAllFinanceReportsQuery());
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
