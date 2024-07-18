using BookStoreApp.Model;
using BookStoreApp.SQLite;
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
    public partial class CustomerManagementDetail : Page
    {
        Customers customers;
        List<Object> customerList;
        string customerId ;

        public CustomerManagementDetail()
        {
            InitializeComponent();
            customers =new Customers();
        }
        public CustomerManagementDetail(string id)
        {
            InitializeComponent();
            try
            {
                customers = new Customers();
                customerId =  id.Substring(9);

                customerList = customers.GetData(int.Parse(customerId));

                if (customerList.Count != 0)
                {
                    CustomerModel customer = customerList[0] as CustomerModel;
                    txtCustomerId.Text = customer.customerId.ToString();
                    txtCustomerName.Text = customer.customerName.ToString();
                    txtEmail.Text = customer.email.ToString();
                    txtAddress.Text = customer.address.ToString();
                }
                else
                {
                    MessageBox.Show($"customer id: {customerId} does not exist");
                    NavigationService.GoBack();
                }
                


            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                txtShowError.Text = "/ Cannot show data";
            }
            

        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
