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
    /// Logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();
            DataContext = new BusinessLogic();
        }        

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            BusinessLogic logic = new BusinessLogic();
            this.SearchResults.ItemsSource = await logic.SearchCurrency(this.SearchBar.Text);
        }

        private void SearchResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Currency selected = (Currency)this.SearchResults.SelectedItem;
            this.SearchResults.SelectedItem = null;
            this.NavigationService.Navigate(new DetailsPage(selected));
        }
    }
}
