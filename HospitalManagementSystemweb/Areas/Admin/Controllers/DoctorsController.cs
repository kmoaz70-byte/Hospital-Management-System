using Dataaccess.Repository.UnitofWork;
using HospitalManagementSystemweb.Models;
using Microsoft.AspNetCore.Mvc;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using SelectListItem = Microsoft.AspNetCore.Mvc.Rendering.SelectListItem;

namespace HospitalManagementSystemweb.Areas.Admin.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IUnitofwork unitofwork;
        private readonly IWebHostEnvironment _enviroment;

        public DoctorsController(IUnitofwork context,IWebHostEnvironment environment)
        {
            unitofwork = context;
            _enviroment = environment;
        }

        //Index
        public IActionResult Index()
        {
            var doctors = unitofwork.DoctorR.GetAll(includeProperties: "Department");
            return View(doctors);
        }

        //Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> departments = unitofwork.DepartmentR.GetAll().Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            });
            ViewBag.departments = departments;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Doctor doctor, IFormFile file)
        {
            string wwwRoot = _enviroment.WebRootPath;
            if (ModelState.IsValid)
            {
                unitofwork.DoctorR.Add(doctor);
                unitofwork.Save();
                TempData["success"] = " Added Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                IEnumerable<SelectListItem> departments = unitofwork.DepartmentR.GetAll().Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                });
                ViewBag.departments = departments;
                return View();
            }


        }

        //Edit
        public IActionResult Edit(int id)
        {
            var doctor = unitofwork.DoctorR.Get(d => d.Id == id);
            IEnumerable<SelectListItem> departments = unitofwork.DepartmentR.GetAll().Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            });
            ViewBag.departments = departments;
            if (doctor != null)
            {
                return View(doctor);
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                unitofwork.DoctorR.Update(doctor);
                unitofwork.Save();
                TempData["update"] = " Updated Successfullly ";
                return RedirectToAction("Index");
            }
            else
            {
                IEnumerable<SelectListItem> departments = unitofwork.DepartmentR.GetAll().Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                });
                ViewBag.departments = departments;
                return View();
            }

        }

        //Delete
        public IActionResult Delete(int id)
        {
            var doctor = unitofwork.DoctorR.Get(d => d.Id == id);
            IEnumerable<SelectListItem> departments = unitofwork.DepartmentR.GetAll().Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            });
            ViewBag.departments = departments;
            if (doctor != null)
            {
                return View(doctor);
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult Delete(Doctor doctor)
        {
            if (doctor != null)
            {
                unitofwork.DoctorR.remove(doctor);
                unitofwork.Save();
                TempData["delete"] = " Deleted Successfully ";
                return RedirectToAction("Index");
            }
            else
            {
                IEnumerable<SelectListItem> departments = unitofwork.DepartmentR.GetAll().Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Id.ToString()
                });
                ViewBag.departments = departments;
                return View();
            }

        }

        #region APICALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Doctor> doctors = unitofwork.DoctorR.GetAll(includeProperties: "Department");
            return Json(new { data = doctors });
        }
        #endregion

    }
}
