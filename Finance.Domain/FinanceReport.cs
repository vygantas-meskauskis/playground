using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Domain
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

        public void AddFinanceRecord(decimal money, string currency, string category, string description, DateTime date, string type)
        {
            var record = new FinanceRecord(money, currency, category, description, date, type);
            _financeRecords.Add(record);
        }
    }
}
