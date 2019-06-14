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
            file.Seek(0, SeekOrigin.Begin);
            var financeRecordItems = new List<FinanceRecordItem>();

            using (var reader = new StreamReader(file))
            {
                var firstLineRead = false;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (!firstLineRead)
                    {
                        firstLineRead = true;
                        continue;
                    }

                    var values = line.Split(';');

                    var date = DateTime.Parse(values[_titleValuePositionDict["Completed Date"]]);
                    var description = values[_titleValuePositionDict["Description"]].Trim();
                    var category = values[_titleValuePositionDict["Category"]].Trim();
                    var balance = double.Parse(values[_titleValuePositionDict["Balance"]].Trim());
                    var notes = values[_titleValuePositionDict["Notes"]].Trim();

                    double transferAmount =
                        string.IsNullOrEmpty(values[_titleValuePositionDict["Paid Out"]].Trim())
                            ? double.Parse(values[_titleValuePositionDict["Paid In"]].Trim())
                            : double.Parse(values[_titleValuePositionDict["Paid Out"]].Trim()) * -1;

                    financeRecordItems.Add(new FinanceRecordItem(date, description, category, transferAmount, balance, notes));
                }
            }

            return financeRecordItems;
        }
    }

    public class NatwestRecordsImportStrategy : IBankRecordsImportStrategy
    {
        public List<FinanceRecordItem> ImportFinanceRecords(Stream file)
        {
            return new List<FinanceRecordItem>();
        }
    }
}
