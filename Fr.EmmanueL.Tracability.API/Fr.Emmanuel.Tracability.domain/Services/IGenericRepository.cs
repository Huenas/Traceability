using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fr.Emmanuel.Tracability.Domain.Services
{
    public interface IGenericRepository<T>
    {
        Task<T> Add(T entity);
        Task<IEnumerable<T>> GetAllAsyn();
        IQueryable<T> GetAll();
        Task<T> GetAsyn(int id);
        T Get(int id);
        T GetComposite(int id1, int id2);
        Task<T> Create(T entity);
        Task<T> Update(object id, T entity);
        /*
        Task<T> UpdateComposite(object id1, object id2, T entity);*/
        Task<bool> Delete(T entity);
        Task BulkInsert(List<T> list);
        Task BulkDelete(List<T> list);

        /*
        T GetByCompositeKey(int id1, int id2);*/
    }
}

