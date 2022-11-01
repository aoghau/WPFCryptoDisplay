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
    /// Logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();
            DataContext = new BusinessLogic();
        }

        private async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BusinessLogic logic = new BusinessLogic();
            this.SearchResults.ItemsSource = await logic.SearchCurrency(this.SearchBar.Text);
        }
    }
}
