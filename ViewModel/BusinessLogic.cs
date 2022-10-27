using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BusinessLogic
    {
        CurrencyContext context;        

        public async Task<List<Currency>> GetTopCurrencies()
        {
            List<Currency> currencies = await context.GetCurrencies();
            List<Currency> topCurrencies = currencies.Where(u => Int32.Parse(u.rank) <= 10).ToList();
            return topCurrencies;
        }

        public BusinessLogic()
        {
            context = new CurrencyContext();
        }

    }
}
