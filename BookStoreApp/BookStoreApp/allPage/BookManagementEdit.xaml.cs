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


        public BookManagementEdit()
        {
            InitializeComponent();
        }
        public BookManagementEdit(string id)
        {
            InitializeComponent();
            ISBN = id.Substring(5);
            txtISBN.Text = ISBN;
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
            NavigationService.GoBack();
        }
    }
}
