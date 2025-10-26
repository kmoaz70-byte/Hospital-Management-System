using Dataaccess.Repository.GenericRepo;
using Models.Models;

namespace Dataaccess.Repository.AppointmentRepository
{
    public interface IAppointmentRepo : IRepository<Appointment>
    {
        void Update(Appointment app);
    }
}
