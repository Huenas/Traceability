using EFCore.BulkExtensions;
using Fr.Emmanuel.Tracability.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fr.Emmanuel.Tracability.Entity.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly TracabilityDbContext _contextFactory;

        public GenericRepository(DbContextFactory contextFactory)
        {
            _contextFactory = contextFactory.CreateDbContext();
        }

        public async Task<T> Add(T entity)
        {
            var createdEntity = _contextFactory.Set<T>().Add(entity);
            _contextFactory.Add(entity);
            await _contextFactory.SaveChangesAsync();

            return createdEntity.Entity;

        }

        public async Task BulkDelete(List<T> list)
        {
            await _contextFactory.BulkDeleteAsync(list);
        }

        public async Task BulkInsert(List<T> list)
        {
            await _contextFactory.BulkInsertAsync(list);
        }

        public async Task<T> Create(T entity)
        {
            var createdEntity = await _contextFactory.Set<T>().AddAsync(entity);
            await _contextFactory.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public async Task<bool> Delete(T entity)
        {
            _contextFactory.Set<T>().Remove(entity);
            await _contextFactory.SaveChangesAsync();
            return true;
        }

        public T Get(int id)
        {
            T entity = _contextFactory.Set<T>().Find(id);

            return entity;
        }

        /*
        public T GetByCompositeKey(int id1, int id2)
        {
            T entity = _contextFactory.Set<T>().Find(id1, id2);

            return entity;
        }
        */

        public IQueryable<T> GetAll()
        {
            return _contextFactory.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsyn()
        {
            IEnumerable<T> entities = await _contextFactory.Set<T>().ToListAsync();

            return entities;
        }

        public async Task<T> GetAsyn(int id)
        {
            T entity = await _contextFactory.Set<T>().FindAsync(id);

            return entity;
        }

        public T GetComposite(int id1, int id2)
        {
            T entity = _contextFactory.Set<T>().Find(id1, id2);

            return entity;
        }

        public async Task<T> Update(object id, T entity)
        {
            if (entity == null)
                return null;

            T exist = _contextFactory.Set<T>().Find(id);

            if (exist != null)
            {
                _contextFactory.Entry(exist).CurrentValues.SetValues(entity);
                await _contextFactory.SaveChangesAsync();
            }

            return entity;
        }
        /*
        public async Task<T> UpdateComposite(object id1, object id2, T entity)
        {
            if (entity == null)
                return null;

            T exist = _contextFactory.Set<T>().Find(id1, id2);

            if (exist != null)
            {
                _contextFactory.Entry(exist).CurrentValues.SetValues(entity);
                await _contextFactory.SaveChangesAsync();
            }

            return entity;
        }
        */
        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _contextFactory.Set<T>();

            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }
    }
}
