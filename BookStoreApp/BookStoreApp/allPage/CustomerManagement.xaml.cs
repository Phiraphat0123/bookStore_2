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
    /// Interaction logic for CustomerManagement.xaml
    /// </summary>
    public partial class CustomerManagement : Page
    {
        public CustomerManagement()
        {
            InitializeComponent();
            createCustomerBTN.OnAction +=MoveToCreate;
            customerListBTN.OnAction +=MoveToList;
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            NavigationService.Navigate(mainMenu);
        }

        private void MoveToCreate()
        {
            CustomerManagementCreate customerManagementCreate = new CustomerManagementCreate(); 
            NavigationService.Navigate(customerManagementCreate);
        }

        private void MoveToList()
        {
            CustomerManagementList customerManagementList = new CustomerManagementList();
            NavigationService.Navigate(customerManagementList);
        }
    }
}
