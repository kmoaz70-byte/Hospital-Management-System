using Dataaccess.Repository.GenericRepo;
using HospitalManagementSystemweb.Models;

namespace Dataaccess.Repository.PatientRepository
{
    public interface IpatientRepo : IRepository<Patient>
    {
        void Update(Patient pat);
    }
}
