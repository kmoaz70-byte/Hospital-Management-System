using Dataaccess.Repository.GenericRepo;
using HospitalManagementSystemweb.Dataaccess.Data;
using HospitalManagementSystemweb.Models;

namespace Dataaccess.Repository.DoctorRepository
{
    public class DoctorRepositoryClass : RepositoryClass<Doctor>, IdoctorRepository
    {
        private readonly MyCmsDbContext _db;
        public DoctorRepositoryClass(MyCmsDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Doctor doctor)
        {
            _db.doctors.Update(doctor);
        }
    }
}
