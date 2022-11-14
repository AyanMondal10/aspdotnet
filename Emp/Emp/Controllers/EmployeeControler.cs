using Microsoft.AspNetCore.Mvc;
using Emp.Models;
namespace Emp.Controllers
{
    public class EmployeeControler : Controller
    {
        public IActionResult output(int eid ,string ename,string edep,int sal)
        {
            Employee e = new Employee();
            e.Id = eid;
            e.Name = ename;
            e.department = edep;
            e.salary=sal;
            return View(e);
        }
        public IActionResult input()
        {
            return View();
        }
    }
}
