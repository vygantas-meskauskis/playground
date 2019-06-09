using Autofac;
using Finance.Client.Interfaces;
using Finance.Client.Services;
using Finance.Domain;
using Finance.Infrastructure;

namespace Finance.Client.Infrastructure.AutofacModules
{
    public class FinanceApplicationAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FinanceRepository>()
                .As<IFinanceRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<FinanceReportService>()
                .As<IFinanceReportService>()
                .InstancePerLifetimeScope();
        }
    }
}
