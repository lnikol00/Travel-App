using Microsoft.AspNetCore.Mvc;

namespace WebApp.WebUI.Controllers
{
    public class TravelOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
