using System;

namespace Finance.Domain
{
    public class FinanceRecord
    {
        public string Category { get; private set; }
        public decimal Money { get; private set; }
        public string Currency{ get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public string Type { get; private set; }

        public FinanceRecord(decimal money, string currency, string category, string description, DateTime date, string type)
        {
            Money = money;
            Currency = currency;
            Category = category;
            Description = description;
            Date = date;
            Type = type;
        }
    }
}
