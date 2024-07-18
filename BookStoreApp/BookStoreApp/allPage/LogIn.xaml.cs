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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void clickLogin(object sender, RoutedEventArgs e)
        {
            Boolean checkStatus = false;
            //validation
            if (txtEmail.Text.Length==0 || txtPassword.Text.Length==0)
            {
                MessageBox.Show("Please input email and password");
                checkStatus = false;
            }
            else
            {
                //when you pass all validation
                // in future I can use database for authentication
                MessageBox.Show($"Welcome {txtEmail.Text}");
                checkStatus = true;
            }

            if (checkStatus)
            {
                MainMenu mainMenu = new MainMenu();
                NavigationService.Navigate(mainMenu);
            }
        }
    }
}
