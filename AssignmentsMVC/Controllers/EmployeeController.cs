
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Servies.Interface.Departments;
using Company.Servies.Interface.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }
        public IActionResult Index(string searchInp)
        {
            if (string.IsNullOrEmpty(searchInp))
            {
                var employee = _employeeService.GetAll();
                return View(employee);
            }
            else
            {
                var employees = _employeeService.GetEmployeeByName(searchInp);
                return View(employees);
            }
        }
        [HttpGet]
       public IActionResult Create ()
       {
            var departments = _departmentService.GetAll(); 
            return View(departments);
           // ViewBag,ViewData,TempData
       }
        [HttpPost]
       public IActionResult Create(Employee employee)
        {
            try
             {

                

                if (ModelState.IsValid) {
                    _employeeService.Add(employee);
                  return RedirectToAction(nameof(Index));

               }
                 ModelState.AddModelError("DepartmentError ", "validationError");
             return View(employee);



             }
             catch (Exception ex)
             {
                 ModelState.AddModelError("DepartmentError ", ex .Message);
                 return View(employee);


             }

       }


        [HttpGet]
         public IActionResult Details(int? id, string ViewName = "Details") 
         {
             var employee = _employeeService.GetById(id);
             if (employee is null)
             {
                return RedirectToAction ("NotFoundPage",null ,"Home");

            }
             return View(employee);
         }
        public IActionResult Update (int id )

        {
            
            return Details(id, "Update");



        }
        [HttpPost]
        public IActionResult Update(int id , Employee employee)

        {
            if (employee.Id !=id)
            {
                return RedirectToAction("NotFoundPage", null, "Home");

            }
            _employeeService.Update(employee);
             

            return RedirectToAction(nameof(Index));

        }
        
        public ActionResult Delete(int id)
        {
            var department = _employeeService.GetById(id);
            if (department is null)
            {
                return RedirectToAction("NotFoundPage", null, "Home");

            }
            _employeeService.Delete(department);
            return RedirectToAction(nameof(Index));

        }

    }
}
