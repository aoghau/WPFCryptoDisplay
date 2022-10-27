using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CurrencyContext
    {
        public async Task<List<Currency>> GetCurrencies()
        {
            var client = new HttpClient();
            var request = await client.GetStringAsync("http://api.coincap.io/v2/assets");
            Wrapper currencies = JsonConvert.DeserializeObject<Wrapper>(request);
            return currencies.data;
        }

        public CurrencyContext() { }
    }
}
