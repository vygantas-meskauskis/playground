using Finance.Client.Interfaces;
using System.Collections.Generic;
using System.IO;
using Finance.Application.Reports.Commands;
using Finance.Application.Reports.Models;
using Finance.Domain.Interfaces;
using MediatR;

namespace Finance.Client.Services
{
    public class FinanceReportService : IFinanceReportService
    {
        private readonly IFinanceRepository _financeRepository;
        private readonly IMediator _mediator;

        public FinanceReportService(IFinanceRepository financeRepository,IMediator _mediator)
        {
            _financeRepository = financeRepository;
            this._mediator = _mediator;
        }

        public IEnumerable<FinanceRecordItem> GetAllFinanceReports()
        {
            return new List<object>
            {
                new
                {
                    Source = "Natwest",
                    Amount = "3.1"
                }
            };
        }

        public void UploadFile(string fileSource, Stream file)
        {
            _mediator.Send(new UploadFileCommand
            {
                FileSource = fileSource,
                FileStream = file
            });
        }
    }
}
