using Microsoft.AspNetCore.Mvc;

namespace DSR_Summer_Practice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
