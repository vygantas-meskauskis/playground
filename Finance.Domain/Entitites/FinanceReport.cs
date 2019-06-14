using System;
using System.Collections.Generic;

namespace Finance.Domain.Entitites
{
    public class FinanceReport
    {
        private List<FinanceRecord> _financeRecords;
        public string Source { get; }
        public string Currency { get; }
        public string GuidId { get; }

        public FinanceReport(string source, string currency)
        {
            Source = source;
            Currency = currency;
            GuidId = Guid.NewGuid().ToString();
        }

        public IReadOnlyList<FinanceRecord> FinanceRecords => _financeRecords;

        public void AddFinanceRecord(double transferAmount, string category, string description, DateTime date, string notes)
        {
            var record = new FinanceRecord(transferAmount, category, description, date, notes);
            if (_financeRecords == null)
            {
                _financeRecords = new List<FinanceRecord>();
            }
            _financeRecords.Add(record);
        }

        public bool IsSourceOf(string source)
        {
            return source.Equals(Source, StringComparison.CurrentCultureIgnoreCase);
        }

    }
}
