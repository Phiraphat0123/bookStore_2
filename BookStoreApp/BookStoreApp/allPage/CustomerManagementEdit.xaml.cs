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
    public partial class CustomerManagementEdit : Page
    {
        Customers customers;
        string customerId;
        List<Object> customerList;
        public CustomerManagementEdit()
        {
            InitializeComponent();
            customers = new Customers();
        }
        public CustomerManagementEdit(string id)
        {
            InitializeComponent();
            
            try
            {
                customers = new Customers();
                customerId = id.Substring(9);
                //MessageBox.Show(customerId);

                customerList = customers.GetData(int.Parse(customerId));
                CustomerModel customer = customerList[0] as CustomerModel;

                if (customerList.Count != 0)
                {
                    txtCustomerId.Text = customerId;
                    txtCustomerId.IsEnabled = false;
                    txtName.Text = customer.customerName;
                    txtAddress.Text = customer.address;
                    txtEmail.Text = customer.email;
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
            }
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EditCustomer(object sender, RoutedEventArgs e)
        {
            try
            {
                int numberOutPut;
                Boolean checkStatus = true;
                //validation
                if(txtCustomerId.Text==string.Empty || txtName.Text==string.Empty 
                    ||txtAddress.Text==string.Empty || txtEmail.Text == string.Empty)
                {
                    txtShowError.Text = "/ Please input all customer information"; 
                    checkStatus = false;
                }
                else
                {
                    if (!int.TryParse(txtCustomerId.Text, out numberOutPut))
                    {
                        checkStatus = false;
                        txtShowError.Text = "/ Customer-id is not number";
                    }
                }

                if (checkStatus)
                {
                    Boolean status = customers.UpdateData(int.Parse(customerId), txtName.Text, txtAddress.Text, txtEmail.Text);
                    if (status) 
                    {
                        CustomerManagementList customerManagementList = new CustomerManagementList();
                        NavigationService.Navigate(customerManagementList);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Can not create customer's information!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Can not create customer's information!");
            }
        }
    }
}
