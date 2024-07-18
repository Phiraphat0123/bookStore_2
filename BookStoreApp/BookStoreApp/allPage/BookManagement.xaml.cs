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
    public partial class BookManagement : Page
    {
        public BookManagement()
        {
            InitializeComponent();
            createBookBTN.OnAction += MoveToCreate;// use element's name to binding method for usercontrol
            bookListBTN.OnAction += MoveToList;
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu(); // using navigate to  main menu
            NavigationService.Navigate(mainMenu);
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
