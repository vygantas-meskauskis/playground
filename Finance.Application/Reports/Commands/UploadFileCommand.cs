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

        public UploadFileCommandHandler(IBankStatementsImportStrategyFactory bankStatementsImportStrategy, IFinanceRepository financeRepository)
        {
            _bankStatementsImportStrategy = bankStatementsImportStrategy;
            _financeRepository = financeRepository;
        }

        public async Task<bool> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            var importStrategy = _bankStatementsImportStrategy.CreateStrategy(request.FileSource);
            var bankStatements = importStrategy.ImportFinanceRecords(request.FileStream);

            //var financeReport = new FinanceReport(request.FileSource);
            //foreach (var financeRecordItem in bankStatements)
            //{
            //    financeReport.AddFinanceRecord(financeRecordItem.TransferAmount);
            //}
            //_financeRepository.Add()
            return true;
            //bankStatements
        }
    }
}
