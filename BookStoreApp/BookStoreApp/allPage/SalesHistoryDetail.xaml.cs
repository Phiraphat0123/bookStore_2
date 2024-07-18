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
    /// <summary>
    /// Interaction logic for SalesHistoryDetail.xaml
    /// </summary>
    public partial class SalesHistoryDetail : Page
    {
        string transactionId;
        Books books;
        Customers customers;
        Sales sales;

        List<Object> transactionList;
        List<Object> customerList;
        List<Object> bookList;
        public SalesHistoryDetail()
        {
            InitializeComponent();
            books = new Books();
            customers = new Customers();
            sales = new Sales();
        }
        public SalesHistoryDetail(string id)
        {
            InitializeComponent();
            transactionId = id.Substring(12);

            books = new Books();
            customers = new Customers();
            sales = new Sales();

            int numberOutput;
            if(int.TryParse(transactionId, out numberOutput))
            {
                transactionList = sales.GetData(int.Parse(transactionId));
                SalesModel transaction = transactionList[0] as SalesModel;

                if (transactionList.Count != 0)
                {
                    bookList = books.GetData(transaction.ISBN);
                    BookModel book = bookList[0] as BookModel;

                    customerList = customers.GetData(transaction.customerId);
                    CustomerModel customer = customerList[0] as CustomerModel;

                    //data assignment
                    txtCustomerId.Text = customer.customerId.ToString();
                    txtCustomerName.Text = customer.customerName.ToString();

                    txtISBN.Text = book.ISBN.ToString();
                    txtBookName.Text = book.title.ToString();

                    txtQuantity.Text = transaction.quantity.ToString();
                    txtTotalPrice.Text = transaction.totalPrice.ToString();

                }
                else
                {
                    MessageBox.Show($"Transactoin id:{transactionId} does't exist");
                    NavigationService.GoBack();
                }


            }
            else
            {   //error
                MessageBox.Show($"{transactionId} is not number");
            }
            



        }
        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
