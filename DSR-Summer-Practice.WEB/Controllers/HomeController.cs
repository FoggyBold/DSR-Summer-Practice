using Microsoft.AspNetCore.Mvc;
using DSR_Summer_Practice.WEB.ViewModels;
using DSR_Summer_Practice.Services.Interfaces;
using DSR_Summer_Practice.WEB.Data.Models;

namespace DSR_Summer_Practice.WEB.Controllers
{
    public class HomeController : Controller
    {
        private IExchangeRateService exchangeRateService;
        public HomeController(IExchangeRateService exchangeRateService)
        {
            this.exchangeRateService = exchangeRateService;
        }
        public IActionResult Index()
        {
            var currencies = exchangeRateService.GetCurrencies();
            List<Currency> currencyList = new List<Currency>();
            foreach(var currency in currencies)
            {
                currencyList.Add(new Currency
                {
                    ID = currency.ID,
                    Name = currency.Name
                });
            }
            CurrenciesViewModel currenciesObj = new CurrenciesViewModel
            {
                currencies = currencyList
            };
            return View(currenciesObj);
        }
    }
}
