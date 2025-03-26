
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Servies.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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


        [HttpGet]
         public IActionResult Details(int? id, string ViewName = "Details") 
         {
             var department =_departmentService.GetById(id);
             if (department is null)
             {
                return RedirectToAction ("NotFoundPage",null ,"Home");

            }
             return View(department);
         }
        public IActionResult Update (int id )

        {
            
            return Details(id, "Update");



        }
        [HttpPost]
        public IActionResult Update(int id ,Department department)

        {
            if (department.Id !=id)
            {
                return RedirectToAction("NotFoundPage", null, "Home");

            }
            _departmentService.Update(department);
             

            return RedirectToAction(nameof(Index));

        }
        
        public ActionResult Delete(int id)
        {
            var department = _departmentService.GetById(id);
            if (department is null)
            {
                return RedirectToAction("NotFoundPage", null, "Home");

            }
            _departmentService.Delete(department);
            return RedirectToAction(nameof(Index));

        }

    }
}
