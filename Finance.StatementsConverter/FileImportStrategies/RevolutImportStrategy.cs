using System;
using System.Collections.Generic;
using System.IO;
using Finance.Application.Interfaces;
using Finance.Application.Reports.Models;

namespace Finance.StatementsConverter.FileImportStrategies
{
    public class RevolutRecordsImportStrategy : IBankRecordsImportStrategy
    {
        private Dictionary<string, int> _titleValuePositionDict = new Dictionary<string, int>
        {
            {"Completed Date", 0 },
            {"Description", 1 },
            {"Paid Out", 2 },
            {"Paid In", 3 },
            {"Exchange Out", 4 },
            {"Exchange In", 5 },
            {"Balance", 6 },
            {"Category", 7 },
            {"Notes", 8 },
        };

        public List<FinanceRecordItem> ImportFinanceRecords(Stream file)
        {
            var financeRecordItems = new List<FinanceRecordItem>();

            using (var reader = new StreamReader(@"C:\test.csv"))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();

                var firstLineRead = false;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (!firstLineRead)
                    {
                        continue;
                    }

                    var values = line.Split(';');

                    var date = DateTime.Parse(values[_titleValuePositionDict["Completed Date"]]);
                    var description = values[_titleValuePositionDict["Description"]];
                    if (string.IsNullOrEmpty(values[_titleValuePositionDict["Paid Out"]].Trim()))
                    {

                    }

                    var financeRecord = new FinanceRecordItem()
                    listA.Add(values[0]);
                    listB.Add(values[1]);
                }
            }

            return new List<FinanceRecordItem>
            {
                new FinanceRecordItem(DateTime.Now, "description", "groceries", -5.25, 10, "notes")
            };
        }

        
    }
}
