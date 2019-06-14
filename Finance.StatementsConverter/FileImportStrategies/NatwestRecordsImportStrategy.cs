using System;
using System.Collections.Generic;
using System.IO;
using Finance.Application.Interfaces;
using Finance.Application.Reports.Models;

namespace Finance.StatementsConverter.FileImportStrategies
{
    public class NatwestRecordsImportStrategy : IBankRecordsImportStrategy
    {

        private Dictionary<string, int> _titleValuePositionDict = new Dictionary<string, int>
        {
            {"Date", 0 },
            {"Type", 1 },
            {"Description", 2 },
            {"Value", 3 },
            {"Balance", 4 },
            {"Account Name", 5 },
            {"Account Number", 6 }
        };

        public List<FinanceRecordItem> ImportFinanceRecords(Stream file)
        {
            file.Seek(0, SeekOrigin.Begin);
            var financeRecordItems = new List<FinanceRecordItem>();

            using (var reader = new StreamReader(file))
            {
                ReadFirstLines(reader, 3);

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    var values = line.Split(';');

                    var date = DateTime.Parse(values[_titleValuePositionDict["Date"]]);
                    var description = values[_titleValuePositionDict["Description"]].Trim();
                    var category = values[_titleValuePositionDict["Category"]].Trim();
                    var balance = double.Parse(values[_titleValuePositionDict["Balance"]].Trim());
                    var notes = values[_titleValuePositionDict["Notes"]].Trim();
                    var transferAmount = double.Parse(values[_titleValuePositionDict["Value"]].Trim());

                    financeRecordItems.Add(new FinanceRecordItem(date, description, category, transferAmount, balance, notes));
                }
            }

            return financeRecordItems;
        }

        private static void ReadFirstLines(TextReader reader, int numberOfLines)
        {
            for (var i = 0; i < numberOfLines; i++)
            {
                reader.ReadLine();
            }
        }
    }
}