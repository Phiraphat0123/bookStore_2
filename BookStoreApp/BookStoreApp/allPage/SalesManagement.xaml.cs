using BookStoreApp.Model;
using BookStoreApp.SQLite;
using System;
using System.CodeDom;
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
    public partial class SalesManagement : Page
    {
        Sales sales;
        Customers customers;
        Books books;
        Boolean submitMode = false;

        private int bookId;
        private int customerId;
        private int qty;
        private int totalPrice;

        public SalesManagement()
        {
            InitializeComponent();
            sales = new Sales();
            books = new Books();
            customers = new Customers();
            
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            
                //clear 
                submitBTN.Content = "Check information";
                txtShowCustomer.Text = string.Empty;
                txtShowISBN.Text = string.Empty;
                txtShowError.Text = string.Empty;

            if (submitMode)  //if true mean submit data to sales database
            {
                
                try
                {
                    //validation
                    if(txtISBN.Text== string.Empty || txtCustomerId.Text== string.Empty 
                        || txtQuantity.Text == string.Empty || txtTotalPrice.Text == string.Empty)
                    {
                        txtShowError.Text = "Please input all information";
                        MessageBox.Show("Cannot complete transaction");
                    }
                    else
                    {

                        Boolean status = sales.AddData(bookId, customerId, qty, totalPrice);
                        if (status) 
                        {
                            MessageBox.Show("Transaction complete");

                            // clear
                            txtISBN.Text = string.Empty;
                            txtCustomerId.Text = string.Empty;
                            txtQuantity.Text = string.Empty;
                            txtTotalPrice.Text = string.Empty;

                            txtCustomerId.IsEnabled = true;
                            txtISBN.IsEnabled = true;
                            txtQuantity.IsEnabled = true;


                            submitMode = false;
                            submitBTN.Content = "Check information";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    txtShowError.Text = "Cannot complete transaction";
                }
            }
            else
            {
                try
                {
                    
                    List<Object> customerList ;
                    List<Object> bookList;

                    //validation
                    if (txtISBN.Text==string.Empty || txtCustomerId.Text== string.Empty ||txtQuantity.Text== string.Empty)
                    {
                        txtShowError.Text = "/ Please input All information";
                        MessageBox.Show("Cannot complete transaction");
                    }
                    else
                    {

                        // use this information for check in each database (book and customer)
                        bookId = int.Parse(txtISBN.Text);
                        customerId = int.Parse(txtCustomerId.Text);
                        qty = int.Parse(txtQuantity.Text);
                        

                        customerList = customers.GetData(customerId);
                        bookList = books.GetData(bookId);
                        

                        if (customerList.Count == 0 || bookList.Count == 0) 
                        {
                            
                            if (customerList.Count==0) txtShowError.Text = $"/ Customer-id: {customerId} does not exist";
                            if(bookList.Count==0)txtShowError.Text = $"/ Book-id: {bookId} does not exist" ;
                        }
                        else if(customerList.Count != 0 && bookList.Count != 0)
                        {
                            
                            CustomerModel customer = customerList[0] as CustomerModel;
                            BookModel book = bookList[0] as BookModel;
                            
                            //assign data for display
                            txtShowCustomer.Text = customer.customerName.ToString();
                            txtCustomerId.IsEnabled = false;

                            txtShowISBN.Text = book.title.ToString();
                            txtISBN.IsEnabled = false;

                            totalPrice = Convert.ToInt32(book.price) * qty;// assign to attribute total price
                            txtTotalPrice.Text = $"{totalPrice}"; // use for display
                            txtQuantity.IsEnabled = false;

                            submitBTN.Content = "Submit";
                            submitMode = true;
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    txtShowError.Text = "Cannot complete transaction";
                }
            }


        }
    }
}
