using System.Linq;
using System.Collections.Generic;
namespace EmployeeManagement.Models{
    public class MockEmployeeRepository: IEmployeeRepository{

        private  List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList= new List<Employee>(){
                new Employee(){Id=1,Name="Pallab",Email="pallab@gmail.com",Department="Eng"},
                new Employee(){Id=2,Name="Hello",Email="hello@gmail.com",Department="HR"}
                
            };
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id){
            return _employeeList.FirstOrDefault(e=>e.Id==Id);

        }

    }
}