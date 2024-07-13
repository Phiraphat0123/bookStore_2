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
    /// Interaction logic for BookManagement.xaml
    /// </summary>
    public partial class BookManagement : Page
    {
        public BookManagement()
        {
            InitializeComponent();
            createBookBTN.OnAction += MoveToCreate;// use element's name for binding method to usercontrol
            //updateBTN.OnAction += MoveToUpdate;
            bookListBTN.OnAction += MoveToList;
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void NavigationBTN_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MoveToCreate()
        {
            BookManagementCreate bookMC = new BookManagementCreate();
            NavigationService.Navigate(bookMC);
        }

        private void MoveToUpdate()
        {
            BookManagementEdit bookME = new BookManagementEdit();
            NavigationService.Navigate(bookME);
        }
        private void MoveToList()
        {
            BookManagementList bookML = new BookManagementList();
            NavigationService.Navigate(bookML);
        }
    }
}
