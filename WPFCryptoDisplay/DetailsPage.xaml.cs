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
using DataAccess;

namespace WPFCryptoDisplay
{
    /// <summary>
    /// Interaction logic for DetailsPage.xaml
    /// </summary>
    public partial class DetailsPage : Page
    {
        Currency currency;

        public DetailsPage(Currency curr)
        {
            InitializeComponent();
            currency = curr;
            this.Loaded += DetailsPage_Loaded;
            this.DataContext = currency;
        }

        private void DetailsPage_Loaded(object sender, RoutedEventArgs e)
        {
            BusinessLogic logic = new BusinessLogic();

        }

        private void MarketDetails_Click(object sender, RoutedEventArgs e)
        {
            MarketDetails details = new MarketDetails(currency.id);
            this.NavigationService.Navigate(details);
        }
    }
}
