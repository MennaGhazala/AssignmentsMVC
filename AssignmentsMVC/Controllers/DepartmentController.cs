using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Servies.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var departments= _departmentService.GetAll();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create ()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department) 
        {
            try
            {
            if (ModelState.IsValid) { 
                 _departmentService.Add(department);
                 return RedirectToAction(nameof(Index));

              }
                ModelState.AddModelError("DepartmentError ", "validationError");
            return View(department);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DepartmentError ", ex .Message);
                return View(department);


            }

        }

       /* public IActionResult Details (int? id) {
            var department =_departmentService.GetById(id);
            if (department == null)
            {
                return View("not found");
                    
            }
            //return department;
        }*/
    }
}
