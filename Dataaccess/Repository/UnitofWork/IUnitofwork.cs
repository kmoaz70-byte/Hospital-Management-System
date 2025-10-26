using Dataaccess.Repository.AppointmentRepository;
using Dataaccess.Repository.DepartmentRepo;
using Dataaccess.Repository.DoctorRepository;
using Dataaccess.Repository.PatientRepository;

namespace Dataaccess.Repository.UnitofWork
{
    public interface IUnitofwork
    {
        public IdoctorRepository DoctorR { get; }
        public IpatientRepo PatientR { get; }
        public IDepartmentRepo DepartmentR { get; }
        public IAppointmentRepo AppointmentR { get; }
        void Save();
    }
}
