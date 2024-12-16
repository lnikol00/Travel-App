using Microsoft.AspNetCore.Mvc;

namespace WebApp.WebUI.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
