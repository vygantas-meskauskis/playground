using System;

namespace Finance.Domain.Entitites
{
    public class FinanceRecord
    {
        public string Category { get; private set; }
        public double TransferAmount { get; private set; }
        public string Currency{ get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public string Type { get; private set; }

        public FinanceRecord(double transferAmount, string currency, string category, string description, DateTime date, string type)
        {
            TransferAmount = transferAmount;
            Currency = currency;
            Category = category;
            Description = description;
            Date = date;
            Type = type;
        }
    }
}
