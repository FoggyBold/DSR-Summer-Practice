using Microsoft.AspNetCore.Mvc;
using DSR_Summer_Practice.Data.Repository;
using DSR_Summer_Practice.ViewModels;

namespace DSR_Summer_Practice.Controllers
{
    public class HomeController : Controller
    {
        private AppDBContent content;
        public HomeController(AppDBContent content)
        {
            this.content = content;
        }
        public IActionResult Index()
        {
            CurrenciesViewModel currenciesObj = new CurrenciesViewModel
            {
                currencies = content.Currencies.ToList()
            };
            return View(currenciesObj);
        }
    }
}
