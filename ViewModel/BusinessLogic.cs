using DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ViewModel
{
    public class BusinessLogic
    {        
        public ObservableCollection<Currency> Currencies { get; set; }
        public ObservableCollection<Currency> TopCurrencies { get; set; }

        public static async Task<List<Currency>> GetCurrenciesAsync()
        {
            var client = new HttpClient();
            var request = await client.GetStringAsync("http://api.coincap.io/v2/assets");
            Wrapper currencies = JsonConvert.DeserializeObject<Wrapper>(request);
            return currencies.data;
        }

        public async Task<ObservableCollection<Currency>> GetTopCurrencies()
        {
            List<Currency> currencies = await GetCurrenciesAsync();
            List<Currency> topCurrencies = currencies.Where(u => Int32.Parse(u.rank) <= 10).ToList();
            return new ObservableCollection<Currency>(topCurrencies);
        }

        //Case-sensitive 
        public async Task<ObservableCollection<Currency>> SearchCurrency(string query)
        {
            List<Currency> currencies = await GetCurrenciesAsync();
            Regex regex = new Regex($@"{query}\w*");
            List<Currency> foundCurrencies = currencies.Where(u => regex.IsMatch(u.name)).ToList();
            return new ObservableCollection<Currency>(foundCurrencies);
        }

        public BusinessLogic(){ }
    }
}
