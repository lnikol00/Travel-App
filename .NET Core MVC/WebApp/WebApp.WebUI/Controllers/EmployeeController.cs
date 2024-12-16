using Microsoft.AspNetCore.Mvc;

namespace WebApp.WebUI.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
