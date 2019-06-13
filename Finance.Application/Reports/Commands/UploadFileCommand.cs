using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Finance.Application.Interfaces;
using Finance.Domain.Entitites;
using Finance.Domain.Interfaces;
using MediatR;

namespace Finance.Application.Reports.Commands
{
    public class UploadFileCommand : IRequest<bool>
    {
        public string FileSource { get; set; }
        public Stream FileStream { get; set; }
    }

    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, bool>
    {
        private readonly IBankStatementsImportStrategyFactory _bankStatementsImportStrategy;
        private readonly IFinanceRepository _financeRepository;
        private readonly IMediator _mediator;

        public UploadFileCommandHandler(IBankStatementsImportStrategyFactory bankStatementsImportStrategy, IFinanceRepository financeRepository, IMediator mediator)
        {
            _bankStatementsImportStrategy = bankStatementsImportStrategy;
            _financeRepository = financeRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            var importStrategy = _bankStatementsImportStrategy.CreateStrategy(request.FileSource);
            var bankStatements = importStrategy.ImportFinanceRecords(request.FileStream);

            var financeReport = await _financeRepository.GetFinanceReportBySourceAsync(request.FileSource);
            if (financeReport == null)
            {
                return await _mediator.Send(new CreateFinanceReportCommand
                {
                    Currency = "Eur",
                    FinanceRecordItems = bankStatements,
                    ReportSource = request.FileSource
                }, cancellationToken);
            }

            _financeRepository.Update(financeReport);
            return true;
        }
    }
}
