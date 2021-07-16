using ReportClients.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportClients.DAL.Interfaces
{
        public interface IGenericAsyncRepository<T>
            where T : BaseEntity
        {
            Task<T> GetById(int id);

            Task<bool> Create(T entity);
            Task Update(T entity);
            Task Delete(T entity);

            Task<IEnumerable<T>> GetAll();
        }
}
