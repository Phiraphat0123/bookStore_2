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
    /// Interaction logic for BookManagementEdit.xaml
    /// </summary>
    public partial class BookManagementEdit : Page
    {
        private string isbn;
        private string title;
        private string description;
        private string price;
        private List<Object> bookList;
        private Books books;
        

        public BookManagementEdit()
        {
            InitializeComponent();
        }
        public BookManagementEdit(string id)
        {
            InitializeComponent();
            try
            {
                books = new Books();
                ISBN = id.Substring(5);
                bookList = books.GetData(int.Parse(ISBN));

                //assign
                BookModel bookDetail = bookList[0] as BookModel;
                txtISBN.Text = ISBN;
                txtISBN.IsEnabled = false;
                txtTitle.Text = bookDetail.title.ToString();
                txtDescription.Text = bookDetail.description.ToString();
                txtPrice.Text = bookDetail.price.ToString();
                MessageBox.Show($"{bookDetail.ISBN.ToString()}, {bookDetail.title.ToString()}");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public BookManagementEdit(string id, string title, string description, string price)
        {
            InitializeComponent();

            ISBN = id.Substring(4);
            Title = title;
            Description = description;
            Price = price;

            txtISBN.Text = ISBN;
            txtTitle.Text = Title;
            txtDescription.Text = Description;
            txtPrice.Text = Price;
        }

        public string ISBN { get => isbn; set => isbn = value; }
        public string Title1 { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string Price { get => price; set => price = value; }

        public void GetTesting()
        {
            MessageBox.Show(ISBN);
            MessageBox.Show(Title);
            MessageBox.Show(Description);
            MessageBox.Show(Price);
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            BookManagementList bookManagementList = new BookManagementList();
            NavigationService.Navigate(bookManagementList);
        }

        private void EditBook(object sender, RoutedEventArgs e)
        {
            try
            {
                BookManagementList bookManagementList = new BookManagementList();
                Boolean status = books.UpdateData(int.Parse(txtISBN.Text),txtTitle.Text,txtDescription.Text,int.Parse(txtPrice.Text));
                if (status)
                {
                    NavigationService.Navigate(bookManagementList);
                }
                else {
                    // show error for user
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
