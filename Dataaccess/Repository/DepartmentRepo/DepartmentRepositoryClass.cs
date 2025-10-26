using Dataaccess.Repository.GenericRepo;
using HospitalManagementSystemweb.Dataaccess.Data;
using Models.Models;

namespace Dataaccess.Repository.DepartmentRepo
{
    public class DepartmentRepositoryClass : RepositoryClass<Department>, IDepartmentRepo
    {
        private readonly MyCmsDbContext _db;
        public DepartmentRepositoryClass(MyCmsDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Department dep)
        {
            _db.Update(dep);
        }
    }
}
