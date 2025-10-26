//using Models.Models.ViewModel;
using Dataaccess.Repository.UnitofWork;
using HospitalManagementSystemweb.Dataaccess.Data;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace HospitalManagementSystemweb.Areas.Admin.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly MyCmsDbContext _db;
        private readonly IUnitofwork unitofwork;
        public DepartmentController(IUnitofwork _unitofwork, MyCmsDbContext db)
        {
            unitofwork = _unitofwork;
            _db = db;
        }


        //Index
        public IActionResult Index()
        {
            var deparment = unitofwork.DepartmentR.GetAll();
            return View(deparment);
        }
        [HttpPost]
        public IActionResult Index(string? search)
        {
            return View();
        }
        //Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department dep)
        {
            if (ModelState.IsValid)
            {
                unitofwork.DepartmentR.Add(dep);
                unitofwork.Save();
                TempData["success"] = " Added Successfully";
                return RedirectToAction("Index");
            }

            return View();

        }
        //Edit
        public IActionResult Edit(int id)
        {

            var department = unitofwork.DepartmentR.Get(p => p.Id == id);
            if (department != null)
            {
                return View(department);
            }
            return NotFound();
        }
        [HttpPost, ActionName("Edit")]
        public IActionResult EditConfirm(Department dep)
        {
            if (ModelState.IsValid)
            {
                unitofwork.DepartmentR.Update(dep);
                unitofwork.Save();
                TempData["update"] = " Updated Successfullly ";
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        //Delete
        public IActionResult Delete(int id)
        {
            var department = unitofwork.DepartmentR.Get(p => p.Id == id);
            if (department != null)
            {
                return View(department);
            }
            return NotFound();
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = unitofwork.DepartmentR.Get(d => d.Id == id);
            if (department != null)
            {
                unitofwork.DepartmentR.remove(department);
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
            IEnumerable<Department> departments = unitofwork.DepartmentR.GetAll();
            return Json(new { data = departments });
        }
        #endregion

    }
}
