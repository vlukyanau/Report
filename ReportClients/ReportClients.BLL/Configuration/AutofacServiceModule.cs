using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
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
