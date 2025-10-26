using Dataaccess.Repository.GenericRepo;
using Models.Models;

namespace Dataaccess.Repository.DepartmentRepo
{
    public interface IDepartmentRepo : IRepository<Department>
    {
        void Update(Department dep);
    }
}
