using System;
using Finance.Application.Interfaces;

namespace Finance.StatementsConverter.FileImportStrategies
{
    public class BankStatementsImportStrategyFactory : IBankStatementsImportStrategyFactory
    {
        public IBankRecordsImportStrategy CreateStrategy(string fileSource)
        {
            switch (fileSource.ToLower())
            {
                case "revolut":
                    return new RevolutRecordsImportStrategy();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
