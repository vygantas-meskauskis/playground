using System;

namespace Finance.Application.Reports.Models
{
    public class FinanceRecordItem
    {
        public FinanceRecordItem(DateTime date, string description, string category, double transferAmount, double balance, string notes)
        {
            Date = date;
            Description = description;
            Category = category;
            TransferAmount = transferAmount;
            Balance = balance;
            Notes = notes;
        }
        public DateTime Date { get; set; } 
        public string Description { get; set; }
        public string Category { get; set; }
        public double TransferAmount { get; set; }
        public double Balance { get; set; }
        public string Notes { get; set; }
    }
}
