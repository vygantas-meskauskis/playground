using Autofac;
using Finance.Application.Interfaces;
using Finance.Client.Interfaces;
using Finance.Client.Services;
using Finance.Domain.Interfaces;
using Finance.Persistence;
using Finance.Persistence.Repositories;
using Finance.StatementsConverter.FileImportStrategies;

namespace Finance.Client.Infrastructure.AutofacModules
{
    public class FinanceApplicationAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FinanceRepository>()
                .As<IFinanceRepository>()
                .InstancePerDependency();

            builder.RegisterType<FinanceReportService>()
                .As<IFinanceReportService>()
                .InstancePerDependency();

            builder.RegisterType<BankStatementsImportStrategyFactory>()
                .As<IBankStatementsImportStrategyFactory>()
                .InstancePerDependency();

            builder.RegisterType<FinanceReportMemoryContext>()
                .As<FinanceReportMemoryContext>()
                .InstancePerDependency();
        }
    }
}
