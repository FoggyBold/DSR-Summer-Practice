using Microsoft.AspNetCore.Mvc;

namespace DSR_Summer_Practice.WEB.Controllers
{
    public class CurrencyExchangeRateDetailsController : Controller
    {
        public IActionResult Index(int ID)
        {
            return View();
        }
    }
}
