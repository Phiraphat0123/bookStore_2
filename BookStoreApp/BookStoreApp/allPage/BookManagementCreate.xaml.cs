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
    /// Interaction logic for BookManagementCreate.xaml
    /// </summary>
    public partial class BookManagementCreate : Page
    {
        Books books;
        Boolean DatabaseStatus;
        List<Object> bookList;

        public BookManagementCreate()
        {
            InitializeComponent();
            books = new Books();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void GetDataTest(object sender, RoutedEventArgs e)
        {
            
            try
            {
                bookList= books.GetData();

                foreach (BookModel objData in bookList)
                {
                    MessageBox.Show($"id:{objData.ISBN}, title:{objData.title}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void CreateNewBook(object sender, RoutedEventArgs e)
        {
            try
            {
                books.AddData(txtISBN.Text, txtTitle.Text, txtDescription.Text, txtPrice.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
