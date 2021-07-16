using Microsoft.EntityFrameworkCore;
using ReportClients.DAL.Context;
using ReportClients.DAL.Repositories;
using ReportClients.DAL.Interfaces;
using Autofac;

namespace ReportClients.DAL.Configuration
{
    public class AutofacRepositoryModule : Module
    {
        private readonly DbContextOptions<PostgreSqlContext> _option;
        public AutofacRepositoryModule(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<PostgreSqlContext>();
            _option = builder.UseNpgsql(connectionString).Options;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericAsyncRepository<>))
                .As(typeof(IGenericAsyncRepository<>))
                .WithParameter("context", new PostgreSqlContext(_option))
                .InstancePerDependency();
        }
    }
}
