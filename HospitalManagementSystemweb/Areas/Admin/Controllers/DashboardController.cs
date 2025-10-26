using Dataaccess.Repository.UnitofWork;
using Microsoft.AspNetCore.Mvc;
using Models.Models.ViewModel;

namespace HospitalManagementSystemweb.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUnitofwork unitofwork;
        public DashboardController(IUnitofwork _unitofwork)
        {
            unitofwork = _unitofwork;
        }
        public IActionResult Index()
        {
            var doctors = unitofwork.DoctorR.GetAll();
            var patients = unitofwork.PatientR.GetAll();
            var departtments = unitofwork.DepartmentR.GetAll();
            var appointments = unitofwork.AppointmentR.GetAll();
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);

            DashboardVM vm = new DashboardVM
            {
                TotalDoctors = doctors.Count(),
                TotalPatients = patients.Count(),
                TotalDepartments = departtments.Count(),
                TotalAppointments = appointments.Count(),
                TodayAppointments = appointments.Where(app => app.Date == date).Count(),
                PendingAppointments = appointments.Where(app => app.Status == "Pending").Count(),
                CompletedAppointments = appointments.Where(app => app.Status == "Confirmed").Count(),
                RecentAppointments = unitofwork.AppointmentR.GetAll(includeProperties: "Patient,Doctor").OrderByDescending(app => app.Time).Take(5).ToList()

            };
            return View(vm);
        }

    }
}
