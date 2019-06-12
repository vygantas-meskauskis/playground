using Finance.Client.Interfaces;
using System.Collections.Generic;
using System.IO;
using Finance.Domain.Interfaces;

namespace Finance.Client.Services
{
    public class FinanceReportService : IFinanceReportService
    {
        private readonly IFinanceRepository _financeRepository;
        public FinanceReportService(IFinanceRepository financeRepository)
        {
            _financeRepository = financeRepository;
        }

        public IEnumerable<object> GetAllFinanceReports()
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
            
        }
    }


}
