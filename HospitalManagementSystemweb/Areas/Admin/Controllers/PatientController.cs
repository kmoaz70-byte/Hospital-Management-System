using Dataaccess.Repository.UnitofWork;
using HospitalManagementSystemweb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystemweb.Areas.Admin.Controllers
{
    public class PatientController : Controller
    {
        private readonly IUnitofwork unitofwork;
        public PatientController(IUnitofwork _unitofwork)
        {
            unitofwork = _unitofwork;
        }

        //Index
        public IActionResult Index()
        {
            IEnumerable<Patient> patients = unitofwork.PatientR.GetAll();
            return View(patients);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                unitofwork.PatientR.Add(patient);
                unitofwork.Save();
                TempData["success"] = " Added Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        //Edit
        public IActionResult Edit(int id)
        {
            var patient = unitofwork.PatientR.Get(p => p.Id == id);
            if (patient != null)
            {
                return View(patient);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                unitofwork.PatientR.Update(patient);
                unitofwork.Save();
                TempData["update"] = " Updated Successfullly ";
                return RedirectToAction("Index");
            }
            return View();

        }
        //Delete
        public IActionResult Delete(int id)
        {
            var patient = unitofwork.PatientR.Get(p => p.Id == id);
            if (patient != null)
            {
                return View(patient);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Delete(Patient patient)
        {


            unitofwork.PatientR.remove(patient);
            unitofwork.Save();
            TempData["delete"] = " Deleted Successfully";
            return RedirectToAction("Index");
        }

        #region APICALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Patient> patients = unitofwork.PatientR.GetAll();
            return Json(new { data = patients });
        }
        #endregion

    }
}
