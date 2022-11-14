using Microsoft.AspNetCore.Mvc;
using Mine.Models;
namespace Mine.Controllers
{
    public class AddController : Controller
    {
        public IActionResult getvalue()
        {
            
            return View();
        }
        public IActionResult setvalue(int x,int y)
        {
            Add a = new Add();
            a.x=x;
            a.y = y;
            a.sum = x + y;
            return View(a);
        }
    }
}
