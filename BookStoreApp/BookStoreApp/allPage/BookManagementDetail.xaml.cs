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
    /// Interaction logic for BookManagementDetail.xaml
    /// </summary>
    public partial class BookManagementDetail : Page
    {
        private Books books;
        private Boolean DatabaseStatus;
        private List<Object> bookList;
        private string isbn;

        public BookManagementDetail()
        {
            InitializeComponent();
        }
        public BookManagementDetail(string id)
        {
            InitializeComponent();
            
            try
            {
                books = new Books();
                ISBN = id.Substring(5);
                

                //MessageBox.Show(ISBN);
                bookList = books.GetData(int.Parse(ISBN));

                //assign value to attribute
                BookModel bookDetail = bookList[0] as BookModel;
                txtISBN.Text = ISBN;
                txtTitle.Text = bookDetail.title.ToString();
                txtDesc.Text = bookDetail.description.ToString();
                txtPrice.Text = bookDetail.price.ToString();
                //MessageBox.Show($"{bookdetail.ISBN.ToString()}, {bookdetail.title.ToString()}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+" testing");
            }
        }

        public string ISBN { get => isbn; set => isbn = value; }
        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
