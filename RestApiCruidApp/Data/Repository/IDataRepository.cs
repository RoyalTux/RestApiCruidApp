using System.Threading.Tasks;

namespace RestApiCruidApp.Data.Repository
{
    public interface IDataRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<T> SaveAsync(T entity);
    }
}
