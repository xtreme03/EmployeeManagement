using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
namespace EmployeeManagement.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {   
        private IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository=employeeRepository;
        }
        [Route("~/Home")]
        [Route("~/")]
        public ViewResult Index(){
            //return Json(new { id=1,name="Pallab Nag"});
            //return _employeeRepository.GetEmployee(1).Name;
            var model=_employeeRepository.GetAllEmployee();
            return View(model);
        }
        /*public ObjectResult Details(){
            Employee model= _employeeRepository.GetEmployee(1);
            return new ObjectResult(model);
        
        }*/
        [Route("{id?}")]
        public ViewResult Details(int? id){
            //Employee model= _employeeRepository.GetEmployee(1);
            //ViewBag.employee=model; //for viewbag no type casting required
           // ViewData["title"]="Page Title";
            //VieBag and ViewData are not strongly typed views we need to use @model property to add strongly typed views
            //return View(model);
            //We will be using a ViewModel Class for the has all the data for the view
            HomeDetailsViewModel homeDetailsViewModel= new HomeDetailsViewModel(){
                Employee = _employeeRepository.GetEmployee(id??1),
                PageTitle = "Employee Details"
            };
            return View(homeDetailsViewModel);
        
            

        
        }


    }
}