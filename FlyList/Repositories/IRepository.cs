using FlyList.Models;

namespace FlyList.Repositories
{
    public interface IRepository<T> where T : SqlEntity
    {
        void Create(T entity);
        T Read(Guid id);
        void Update(T entity);
        void Delete(Guid id);
        IEnumerable<T> GetAll();
    }
}
