using Microsoft.EntityFrameworkCore;
using ReportClients.DAL.Entities;

namespace ReportClients.DAL.Context
{
    public class PostgreSqlContext : DbContext
    {

        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {

        }

        public DbSet<ClientEntity> Clients { get; set; }

    }
}
