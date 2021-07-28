using Autofac;
using System;
using System.Reflection;
using Module = Autofac.Module;

namespace ReportClients.BLL.Configuration
{
    public class AutofacServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                .Where(type => type.Name.EndsWith("Service", StringComparison.Ordinal))
                .AsImplementedInterfaces()
                .InstancePerDependency();
        }
    }
}
