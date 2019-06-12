using Autofac;
using Finance.Client.Interfaces;
using Finance.Client.Services;
using Finance.Domain.Interfaces;
using Finance.Persistence;
using Finance.Persistence.Repositories;

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

            builder.RegisterType<FinanceReportMemoryContext>()
                .As<FinanceReportMemoryContext>()
                .InstancePerDependency();
        }
    }
}
