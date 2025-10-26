using Dataaccess.Repository.AppointmentRepository;
using Dataaccess.Repository.DepartmentRepo;
using Dataaccess.Repository.DoctorRepository;
using Dataaccess.Repository.PatientRepository;
using HospitalManagementSystemweb.Dataaccess.Data;

namespace Dataaccess.Repository.UnitofWork
{
    public class UnitofworkClass : IUnitofwork
    {
        private readonly MyCmsDbContext _db;

        public IdoctorRepository DoctorR { get; private set; }

        public IpatientRepo PatientR { get; private set; }
        public IDepartmentRepo DepartmentR { get; private set; }
        public IAppointmentRepo AppointmentR { get; private set; }
        public UnitofworkClass(MyCmsDbContext db)
        {
            _db = db;
            DoctorR = new DoctorRepositoryClass(db);
            PatientR = new PatientRepoClass(db);
            DepartmentR = new DepartmentRepositoryClass(db);
            AppointmentR = new AppointmentRepoClass(db);
        }

        public void Save()
        {
            _db.SaveChanges();

        }
    }
}
