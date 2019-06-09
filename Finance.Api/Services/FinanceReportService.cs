using Finance.Client.Interfaces;
using Finance.Domain;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
