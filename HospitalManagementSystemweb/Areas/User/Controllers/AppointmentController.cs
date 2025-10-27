using Dataaccess.Repository.UnitofWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Models.Models.ViewModel;
using Models.Models;
using Models.Models.ViewModel;

namespace HospitalManagementSystemweb.Areas.Admin.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IUnitofwork unitofwork;
        public AppointmentController(IUnitofwork iuow)
        {
            unitofwork = iuow;
            
        }


        //Index
        public IActionResult Index()
        {
            IEnumerable<Appointment> appointments = unitofwork.AppointmentR.GetAll(includeProperties: "Doctor,Patient");
            return View(appointments);
        }
        [HttpPost]
        public IActionResult Index(string? search)
        {
            return View();
        }

        //Create
        public IActionResult Book()
        {
            var doctors = unitofwork.DoctorR.GetAll().Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            });
            IEnumerable<SelectListItem> patients = unitofwork.PatientR.GetAll().Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            });
            AppointmentVM appointmentVM = new AppointmentVM
            {
                appointment = new(),
                doctorsSL = doctors,
                patientsSL = patients
            };
            return View(appointmentVM);
        }
        [HttpPost]
        public IActionResult Book(AppointmentVM vm)
        {

            if (ModelState.IsValid)
            {
                unitofwork.AppointmentR.Add(vm.appointment);
                unitofwork.Save();
                TempData["success"] = " Added Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                var doctors = unitofwork.DoctorR.GetAll().Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                });
                IEnumerable<SelectListItem> patients = unitofwork.PatientR.GetAll().Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                });
                AppointmentVM appointmentVM = new AppointmentVM
                {
                    appointment = vm.appointment,
                    doctorsSL = doctors,
                    patientsSL = patients
                };
                return View(appointmentVM);
            }
        }

        //Edit
        public IActionResult Edit(int id)
        {
            var doctors = unitofwork.DoctorR.GetAll().Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            });
            IEnumerable<SelectListItem> patients = unitofwork.PatientR.GetAll().Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            });
            AppointmentVM appointment = new AppointmentVM
            {
                appointment = unitofwork.AppointmentR.Get(a => a.Id == id),
                doctorsSL = doctors,
                patientsSL = patients
            };

            if (appointment != null)
            {
                return View(appointment);
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(AppointmentVM app)
        {

            unitofwork.AppointmentR.Update(app.appointment);
            unitofwork.Save();
            TempData["update"] = " Updated Successfullly ";
            return RedirectToAction("Index");
        }

        //Delete
        public IActionResult Delete(int id)
        {
            var doctors = unitofwork.DoctorR.GetAll().Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            });
            IEnumerable<SelectListItem> patients = unitofwork.PatientR.GetAll().Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            });
            AppointmentVM appointment = new AppointmentVM
            {
                appointment = unitofwork.AppointmentR.Get(a => a.Id == id),
                doctorsSL = doctors,
                patientsSL = patients
            };

            if (appointment != null)
            {
                return View(appointment);
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult Delete(AppointmentVM app)
        {
            if (app != null)
            {
                unitofwork.AppointmentR.remove(app.appointment);
                unitofwork.Save();
                TempData["delete"] = " Deleted Successfully";
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        #region APICALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Appointment> appointments = unitofwork.AppointmentR.GetAll(includeProperties: "Doctor,Patient");
            return Json(new { data = appointments });
        }

        #endregion



    }
}


