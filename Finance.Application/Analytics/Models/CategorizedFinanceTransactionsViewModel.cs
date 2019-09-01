namespace Finance.Application.Analytics.Models
{
    public class CategorizedFinanceTransactionsViewModel
    {
        public string Category { get; set; }
        public string Percentage { get; set; }
        public string Amount { get; set; }
        public int NumberOfTransactions { get; set; }
    }

}
