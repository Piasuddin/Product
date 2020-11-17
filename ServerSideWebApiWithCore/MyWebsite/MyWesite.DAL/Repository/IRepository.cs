using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyWesite.DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T model);
        Task<List<T>> AddRangeAsync(List<T> models);
        Task<T> UpdateAsync(T model);
        Task<T> RemoveAsync(T model);
        Task<List<T>> RemoveRangeAsync(List<T> models);
        Task<T> GetAsync(Object id);
        IEnumerable<T> Get();
    }
}
