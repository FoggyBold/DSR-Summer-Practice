﻿using DSR_Summer_Practice.Data.Models;

namespace DSR_Summer_Practice.Interfaces
{
    public interface IServiceWithCurrency
    {
        IEnumerable<string> GetCurrencyNames(String URLString);
        IEnumerable<ExchangeRate> GetInformationAboutExchangeRate(DateTime first, DateTime second, string currency);
    }
}
