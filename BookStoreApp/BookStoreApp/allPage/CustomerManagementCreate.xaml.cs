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
    public partial class CustomerManagementCreate : Page
    {
        Customers customers;

        public CustomerManagementCreate()
        {
            InitializeComponent();
            customers = new Customers();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CreateNewCustomer(object sender, RoutedEventArgs e)
        {
            txtShowError.Text = string.Empty;
            try
            {
                int numberOutPut;
                Boolean checkStatus = true;
                //validation
                if (txtCustomerId.Text.Length == 0 || txtCustomerName.Text.Length == 0 ||
                    txtAddress.Text.Length == 0 || txtEmail.Text.Length == 0)
                {
                    checkStatus = false;
                    txtShowError.Text = "/ Please input customer information";
                }
                else
                {
                    // check is number?
                    if (!int.TryParse(txtCustomerId.Text, out numberOutPut))
                    {
                        checkStatus = false;
                        txtShowError.Text = "/ Customer-id is not number";
                    }
                }

                if (checkStatus)
                {
                    Boolean status = customers.AddData(int.Parse(txtCustomerId.Text), txtCustomerName.Text, txtAddress.Text, txtEmail.Text);
                    if (status)
                    {
                        MessageBox.Show("Add new customer successful");

                        //clear
                        txtCustomerId.Text = string.Empty;
                        txtCustomerName.Text = string.Empty;
                        txtAddress.Text= string.Empty;
                        txtEmail.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Can not create customer's information!");
                }

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Can not create customer's information!");
            }
        }
    }
}
