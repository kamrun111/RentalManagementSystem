using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Building.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // T- Flat
        IEnumerable<T> GetAll(string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);// getfirstordefault(e=>e.id==Id)
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);// list of entity
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string includeProperties = null);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null,string includeProperties = null);
        Task AddAsync(T entity);
    }

}
