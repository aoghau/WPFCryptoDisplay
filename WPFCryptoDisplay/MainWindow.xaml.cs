using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Microsoft.Xaml.Behaviors;
using DataAccess;
using ViewModel;

namespace WPFCryptoDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
       
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;            
            this.DataContext = new BusinessLogic();
        }



        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {            
            await LoadData();
        }        

        public async Task LoadData()
        {
            BusinessLogic logic = new BusinessLogic();
            this.TopTen.ItemsSource = await logic.GetTopCurrencies();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchPage page = new SearchPage();
            this.NavigationService.Navigate(page);
        }             

        private void TopTen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Currency selected = (Currency)this.TopTen.SelectedItem;
            this.TopTen.SelectedItem = null;
            this.NavigationService.Navigate(new DetailsPage(selected));
        }
    }
}
