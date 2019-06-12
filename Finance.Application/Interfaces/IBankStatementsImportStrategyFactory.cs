namespace Finance.Application.Interfaces
{
    public interface IBankStatementsImportStrategyFactory
    {
        IBankRecordsImportStrategy CreateStrategy(string fileSource);
    }
}