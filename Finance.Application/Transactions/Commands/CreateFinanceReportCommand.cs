using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Finance.Application.Reports.Models;
using Finance.Domain.Entitites;
using Finance.Domain.Interfaces;
using MediatR;

namespace Finance.Application.Reports.Commands
{
    public class CreateFinanceReportCommand : IRequest<bool>
    {
        public string ReportSource { get; set; }
        public string Currency { get; set; }
        public IEnumerable<FinanceRecordItem> FinanceRecordItems { get; set; }
    }

    public class CreateFinanceReportCommandHandler : IRequestHandler<CreateFinanceReportCommand, bool>
    {
        private readonly IFinanceRepository _financeRepository;

        public CreateFinanceReportCommandHandler(IFinanceRepository financeRepository)
        {
            _financeRepository = financeRepository;
        }
        public Task<bool> Handle(CreateFinanceReportCommand request, CancellationToken cancellationToken)
        {
            var financeReport = new FinanceReport(request.ReportSource, request.Currency);
            foreach (var recordItem in request.FinanceRecordItems)
            {
                financeReport.AddFinanceRecord(recordItem.TransferAmount, recordItem.Balance, recordItem.Category, recordItem.Description, recordItem.Date, recordItem.Notes);
            }

            _financeRepository.Add(financeReport);
            return Task.FromResult(true);
        }
    }
}
