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


namespace BookStoreApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Source = new Uri("./allPage/LogIn.xaml",UriKind.Relative); //ใชเเพื่อประกาศ Main frame
        }

        //private void TESTING(object sender, RoutedEventArgs e)
        //{
            //bookManagement.AddData("1","super","hero","12.5");
            //List<string> booksList =bookManagement.GetData();
            //MessageBox.Show(string.Join(",\n",booksList));
            //MainMenu mainMenu = new MainMenu();
            //this.NavigationService.Navigate(mainMenu);
        //}
    }
}
