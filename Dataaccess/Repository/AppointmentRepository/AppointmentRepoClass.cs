using Dataaccess.Repository.GenericRepo;
using HospitalManagementSystemweb.Dataaccess.Data;
//using HospitalManagementSystemweb.Migrations;
using Models.Models;

namespace Dataaccess.Repository.AppointmentRepository
{
    public class AppointmentRepoClass : RepositoryClass<Appointment>, IAppointmentRepo
    {
        private readonly MyCmsDbContext _db;
        public AppointmentRepoClass(MyCmsDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Appointment app)
        {

            _db.Update(app);
        }
    }
}
