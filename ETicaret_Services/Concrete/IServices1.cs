using System.Linq.Expressions;

namespace ETicaret_Services.Concrete
{
    public interface IServices1<T> where T : class
    {
        void Add(T entity);
        Task AddAsync(T entity);
        void Delete(T entity);
        T Find(int id);
        Task<T> FindAsync(int id);
        T Get(Expression<Func<T, bool>> expression);
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> GetQueryable();
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void Update(T entity);
    }
}