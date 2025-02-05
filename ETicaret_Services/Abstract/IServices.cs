using ETicaret_Core.Entities;
using System.Linq.Expressions;

namespace ETicaret_Services.Abstract
{
    internal interface IServices<T> where T : IEntitiy, new()
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> expressions);
        IQueryable<T> GetQueryable();
        T Get(Expression<Func<T, bool>> expression);
        T Find(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int SaveChanges();

        // Asenkron Metotlar
        Task<T> FindAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> expressions);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expressions);
        Task AddAsync(T entity);
        Task<int> SaveChangesAsync();
    }
}
