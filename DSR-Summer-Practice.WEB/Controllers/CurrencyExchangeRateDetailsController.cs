using DSR_Summer_Practice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DSR_Summer_Practice.WEB.Data.Models;
using DSR_Summer_Practice.WEB.ViewModels;

namespace DSR_Summer_Practice.WEB.Controllers
{
    public class CurrencyExchangeRateDetailsController : Controller
    {
        private IExchangeRateService exchangeRateService;
        public CurrencyExchangeRateDetailsController(IExchangeRateService exchangeRateService)
        {
            this.exchangeRateService = exchangeRateService;
        }
        public IActionResult Index(int id)
        {
            DateTime dateTime = DateTime.Now.AddDays(-10);
            var exchangeRate = exchangeRateService.GetExchangeRates(id, dateTime, DateTime.Now);
            List<ExchangeRate> list = new List<ExchangeRate>();
            foreach(var exchRate in exchangeRate)
            {
                list.Add(new ExchangeRate
                {
                    CurrencyName = exchRate.CurrencyName,
                    DateTime = dateTime,
                    Value = exchRate.Value
                });
            }
            ExchangeRateOfOneCurrencyViewModel exchangeRateOfOneCurrencyViewModel = new ExchangeRateOfOneCurrencyViewModel
            {
                currencies = list
            };
            return View(exchangeRateOfOneCurrencyViewModel);
        }
    }
}
