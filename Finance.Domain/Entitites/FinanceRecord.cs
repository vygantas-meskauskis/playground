using System;

namespace Finance.Domain.Entitites
{
    public class FinanceRecord
    {
        public string Category { get; private set; }
        public double TransferAmount { get; private set; }
        public double Balance { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public string Notes { get; private set; }

        public FinanceRecord(double transferAmount, double balance, string category, string description, DateTime date, string notes)
        {
            TransferAmount = transferAmount;
            Balance = balance;
            Category = category;
            Description = description;
            Date = date;
            Notes = notes;
        }
    }
}
