using System.Linq.Expressions;

namespace Dataaccess.Repository.GenericRepo
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filterd, string? includeProperties = null);
        void Add(T obj);
        void remove(T obj);
        void removeall(IEnumerable<T> objects);
    }
}
