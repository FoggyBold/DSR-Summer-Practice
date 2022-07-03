using DSR_Summer_Practice.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using DSR_Summer_Practice.Interfaces;

namespace DSR_Summer_Practice.Controllers
{
    public class CurrencyExchangeRateDetailsController : Controller
    {
        private readonly ICurrencyInformation currencyInformation;

        public CurrencyExchangeRateDetailsController(ICurrencyInformation currencyInformation)
        {
            this.currencyInformation = currencyInformation;            
        }
        public IActionResult Index(int ID)
        {
            return View();
        }
    }
}
