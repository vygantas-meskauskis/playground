using System;

namespace Finance.Application.Reports.Models
{
    public class FinanceRecordItem
    {
        public DateTime Date { get; set; } 
        public string Description { get; set; }
        public string Category { get; set; }
        public double TransferAmount { get; set; }
        public double Balance { get; set; }
    }
}
