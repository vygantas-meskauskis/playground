using System;
using System.Collections.Generic;
using System.IO;
using Finance.Application.Interfaces;
using Finance.Application.Reports.Models;

namespace Finance.StatementsConverter.FileImportStrategies
{
    class RevolutRecordsImportStrategy : IBankRecordsImportStrategy
    {
        public List<FinanceRecordItem> ImportFinanceRecords(Stream file)
        {
            return new List<FinanceRecordItem>
            {
                new FinanceRecordItem
                {
                    Balance = 10,
                    Category = "groceries",
                    Date = DateTime.Now,
                    Description = "description",
                    TransferAmount = -5.25
                }
            };
        }
    }
}
