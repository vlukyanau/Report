using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReportClients.DAL.Context;
using ReportClients.DAL.Entities;
using ReportClients.DAL.Interfaces;

namespace ReportClients.DAL.Repositories
{
    public class GenericAsyncRepository<T> : IGenericAsyncRepository<T>
        where T : BaseEntity
    {
        private readonly PostgreSqlContext _context;

        public GenericAsyncRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
