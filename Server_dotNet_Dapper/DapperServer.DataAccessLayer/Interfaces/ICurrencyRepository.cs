using DapperServer.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.DataAccessLayer.Interfaces
{
    public interface ICurrencyRepository
    {
        Task ExchangeRate(ExchangeRateModel request);
        Task UpdateCurrency(UpdateCurrencyModel request);
        Task<IEnumerable<CurrencyModel>> GetCurrency();
    }
}
