using Dataaccess.Repository.GenericRepo;
using HospitalManagementSystemweb.Models;

namespace Dataaccess.Repository.DoctorRepository
{
    public interface IdoctorRepository : IRepository<Doctor>
    {
        void Update(Doctor doctor);
    }
}
