using Microsoft.AspNetCore.Mvc;
using DSR_Summer_Practice.Data.Repository;
using DSR_Summer_Practice.ViewModels;
using DSR_Summer_Practice.Interfaces;

namespace DSR_Summer_Practice.Controllers
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
