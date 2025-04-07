
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Servies.Interface.Departments;
using Company.Servies.Interface.Dto;
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
            IEnumerable<EmployeeDto> employees = new List<EmployeeDto>();
            if (string.IsNullOrEmpty(searchInp))
            
                employees = _employeeService.GetAll();
                
            
            else
            
                 employees = _employeeService.GetEmployeeByName(searchInp);
                return View(employees);
            
        }
        [HttpGet]
       public IActionResult Create ()
       {
            ViewBag.Departments= _departmentService.GetAll(); 
            return View();
           // ViewBag,ViewData,TempData
       }
       [HttpPost]
       public IActionResult Create(EmployeeDto employeeDto)
        
        {
            try
             {

                

                if (ModelState.IsValid) {
                    _employeeService.Add(employeeDto);
                  return RedirectToAction(nameof(Index));

               }
                 ModelState.AddModelError("DepartmentError ", "validationError");
             return View(employeeDto);



             }
             catch (Exception ex)
             {
                 ModelState.AddModelError("DepartmentError ", ex .Message);
                 return View(employeeDto);


             }

       }
        /*

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
        public IActionResult Update(int id , Data.Models.Employee employee)

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

        }*/

    }
}
