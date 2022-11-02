using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;

namespace WPFCryptoDisplay
{
    /// <summary>
    /// Interaction logic for MarketDetails.xaml
    /// </summary>
    public partial class MarketDetails : Page
    {
        string currency;

        public MarketDetails(string currencyId)
        {
            InitializeComponent();
            currency = currencyId;
            this.Loaded += MarketDetails_Loaded;
            this.DataContext = currency;
        }

        private async void MarketDetails_Loaded(object sender, RoutedEventArgs e)
        {
            BusinessLogic logic = new BusinessLogic();
            this.Markets.ItemsSource = await logic.GetMarkets(currency);
        }
    }
}
