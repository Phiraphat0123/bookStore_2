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

namespace BookStoreApp.allPage
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void ToBookM(object sender, RoutedEventArgs e)
        {
            BookManagementCreate bookM = new BookManagementCreate();
            NavigationService.Navigate(bookM);
        }

        private void ToCustomerM(object sender, RoutedEventArgs e)
        {
            CustomerManagement customerM = new CustomerManagement();
            NavigationService.Navigate(customerM);
        }

        private void ToSalesHistory(object sender, RoutedEventArgs e)
        {
            SalesHistory salesHistory = new SalesHistory();
            NavigationService.Navigate(salesHistory);
        }

        private void ToSales(object sender, RoutedEventArgs e)
        {
            Sales sales = new Sales();
            NavigationService.Navigate(sales);
        }
    }
}
