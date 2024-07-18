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
        string isbn;
        string title;
        string description;
        string price;
        List<Object> bookList;
        Books books;
        

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
                isbn = id.Substring(5);
                bookList = books.GetData(int.Parse(isbn));

                //assign
                BookModel bookDetail = bookList[0] as BookModel;
                txtISBN.Text = isbn;
                txtISBN.IsEnabled = false;
                txtTitle.Text = bookDetail.title.ToString();
                txtDescription.Text = bookDetail.description.ToString();
                txtPrice.Text = bookDetail.price.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public BookManagementEdit(string id, string bookName, string bookDesc, string bookPrice)
        {
            InitializeComponent();

            isbn = id.Substring(4);
            title = bookName;
            description = bookDesc ;
            price = bookPrice;

            txtISBN.Text = isbn;
            txtTitle.Text = title;
            txtDescription.Text = description;
            txtPrice.Text = price;
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
                int numberOutPut;
                Boolean checkStatus = true;
                //validation
                // check all data null?
                if (txtISBN.Text.Length == 0 || txtTitle.Text.Length == 0 ||
                    txtDescription.Text.Length == 0 || txtPrice.Text.Length == 0)
                {
                    checkStatus = false;
                    txtShowError.Text = "/ Please input all book information";
                }
                else
                {
                    // check is number?
                    if (!int.TryParse(txtISBN.Text, out numberOutPut))
                    {
                        checkStatus = false;
                        txtShowError.Text = "/ Book-id(ISBN) is not number";
                    }
                    if (!int.TryParse(txtPrice.Text, out numberOutPut))
                    {
                        checkStatus = false;
                        txtShowError.Text += "/ Price is not number";
                    }
                }

                if (checkStatus)
                {
                    
                    Boolean status = books.UpdateData(int.Parse(txtISBN.Text), txtTitle.Text, txtDescription.Text, int.Parse(txtPrice.Text));
                    if (status)
                    {
                        BookManagementList bookManagementList = new BookManagementList();
                        NavigationService.Navigate(bookManagementList);

                        //NavigationService.GoBack();
                    } 
                }
                else
                {
                    MessageBox.Show("Can not create book's information!");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Can not create book's information!");
            }

        }
    }
}
