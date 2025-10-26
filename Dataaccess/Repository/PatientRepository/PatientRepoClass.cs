using Dataaccess.Repository.GenericRepo;
using HospitalManagementSystemweb.Dataaccess.Data;
using HospitalManagementSystemweb.Models;

namespace Dataaccess.Repository.PatientRepository
{
    class PatientRepoClass : RepositoryClass<Patient>, IpatientRepo
    {
        private readonly MyCmsDbContext _db;
        public PatientRepoClass(MyCmsDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Patient pat)
        {
            _db.patients.Update(pat);
        }
    }
}
