using ReportClients.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportClients.DAL.Interfaces
{
        public interface IGenericAsyncRepository<T>
            where T : BaseEntity
        {
            Task<T> GetByIdAsync(int id);

            Task CreateAsync(T entity);
            Task Update(T entity);
            Task Delete(int id);

            Task<IEnumerable<T>> GetAllAsync();
        }
}
