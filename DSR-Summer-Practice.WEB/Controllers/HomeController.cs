using Microsoft.AspNetCore.Mvc;
using DSR_Summer_Practice.WEB.ViewModels;
using DSR_Summer_Practice.WEB.Interfaces;

namespace DSR_Summer_Practice.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICurrencyRepository currencyInformation;
        public HomeController(ICurrencyRepository currencyInformation)
        {
            this.currencyInformation = currencyInformation;
        }
        public IActionResult Index()
        {
            CurrenciesViewModel currenciesObj = new CurrenciesViewModel
            {
                currencies = currencyInformation.getAllNames()
            };
            return View(currenciesObj);
        }
    }
}
