using HospitalManagementSystemweb.Dataaccess.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dataaccess.Repository.GenericRepo
{
    public class RepositoryClass<T> : IRepository<T> where T : class
    {
        private readonly MyCmsDbContext _db;
        private DbSet<T> dbset { get; set; }
        public RepositoryClass(MyCmsDbContext db)
        {
            _db = db;
            this.dbset = db.Set<T>();

        }

        public void Add(T obj)
        {
            dbset.Add(obj);
        }

        public T Get(Expression<Func<T, bool>> filterd, string? includeProperties = null)
        {
            IQueryable<T> query = dbset;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeprop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop.Trim());
                }
            }
            query = query.Where(filterd);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbset;
            if (!string.IsNullOrEmpty(includeProperties))
            {

                foreach (var prop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop.Trim());
                }
            }

            return query.ToList();
        }

        public void remove(T obj)
        {
            dbset.Remove(obj);
        }

        public void removeall(IEnumerable<T> objects)
        {
            dbset.RemoveRange(objects);
        }
    }
}
