using MyWesite.DAL.MyWebsiteDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWesite.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MyWebsiteDataDbContext dbContext;

        public Repository(MyWebsiteDataDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<T> AddAsync(T model)
        {
            await dbContext.Set<T>().AddAsync(model);
            await dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<T> GetAsync(Object id)
        {
            T data = await dbContext.Set<T>().FindAsync(id);
            return data;
        }

        public IEnumerable<T> Get()
        {
            return dbContext.Set<T>().ToList();
        }

        public async Task<T> RemoveAsync(T model)
        {
            dbContext.Set<T>().Remove(model);
            await dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<T> RemoveAsync(Object id)
        {
            T data = await dbContext.Set<T>().FindAsync(id);
            dbContext.Set<T>().Remove(data);
            await dbContext.SaveChangesAsync();
            return data;
        }

        public async Task<T> UpdateAsync(T model)
        {
            dbContext.Set<T>().Update(model);
            await dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<List<T>> AddRangeAsync(List<T> models)
        {
            await dbContext.Set<T>().AddRangeAsync(models);
            await dbContext.SaveChangesAsync();
            return models;
        }

        public async Task<List<T>> RemoveRangeAsync(List<T> models)
        {
            dbContext.Set<T>().RemoveRange(models);
            await dbContext.SaveChangesAsync();
            return models;
        }
    }
}
