using System;
using System.Collections.Generic;

namespace Finance.Domain.Entitites
{
    public class FinanceReport
    {
        private readonly List<FinanceRecord> _financeRecords;
        private string _moneySourceName;

        public FinanceReport(string moneySourceName)
        {
            _moneySourceName = moneySourceName;
        }

        public IReadOnlyList<FinanceRecord> FinanceRecords => _financeRecords;

        public void AddFinanceRecord(double transferAmount, string currency, string category, string description, DateTime date, string type)
        {
            var record = new FinanceRecord(transferAmount, currency, category, description, date, type);
            _financeRecords.Add(record);
        }
    }
}
