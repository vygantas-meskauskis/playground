using System;
using System.Linq.Expressions;
using Finance.Domain.Entitites;

namespace Finance.Application.Reports.Models
{
    public class FinanceRecordViewModel
    {
        public string Category { get; set; }
        public double TransferAmount { get; set; }
        public double Balance { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        public static Expression<Func<FinanceRecord, FinanceRecordViewModel>> Projection
        {
            get
            {
                return financeRecord => new FinanceRecordViewModel
                {
                    TransferAmount = financeRecord.TransferAmount,
                    Category = financeRecord.Category,
                    Date = financeRecord.Date,
                    Description = financeRecord.Description,
                    Notes = financeRecord.Notes,
                    Balance = financeRecord.Balance
                };
            }
        }

        public static FinanceRecordViewModel Create(FinanceRecord financeRecord)
        {
            return Projection.Compile().Invoke(financeRecord);
        }
    }
}