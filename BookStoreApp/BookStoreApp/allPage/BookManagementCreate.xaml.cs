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
    public partial class BookManagementCreate : Page
    {
        Books books;
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

        private void CreateNewBook(object sender, RoutedEventArgs e)
        {
            txtShowError.Text ="";
            try
            {
                int numberOutPut;
                Boolean checkStatus=true;
                //validation
                // check all data null?
                if (txtISBN.Text.Length==0 || txtTitle.Text.Length==0 || 
                    txtDescription.Text.Length==0 || txtPrice.Text.Length==0)
                {
                    checkStatus =false;
                    txtShowError.Text = "/ Please input book information";
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
                 

                // add data
                if (checkStatus)
                {
                    Boolean status = books.AddData(int.Parse(txtISBN.Text), txtTitle.Text, txtDescription.Text, int.Parse(txtPrice.Text));
                    if (status)
                    {
                        MessageBox.Show("Create book information successful");
                        // clear data
                        txtISBN.Text = string.Empty;
                        txtTitle.Text = string.Empty;
                        txtDescription.Text = string.Empty;
                        txtPrice.Text = string.Empty;
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
