using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {   
        private IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository=employeeRepository;
        }
        public string Index(){
            //return Json(new { id=1,name="Pallab Nag"});
            return _employeeRepository.GetEmployee(1).Name;
        }
        /*public ObjectResult Details(){
            Employee model= _employeeRepository.GetEmployee(1);
            return new ObjectResult(model);
        
        }*/
        public ViewResult Details(){
            Employee model= _employeeRepository.GetEmployee(1);
            ViewData["employee"]=model;
            ViewData["title"]="Page Title";
            return View();
        
        }


    }
}