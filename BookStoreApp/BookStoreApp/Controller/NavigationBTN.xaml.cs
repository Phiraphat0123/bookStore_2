using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace BookStoreApp.Controller
{

    public partial class NavigationBTN : UserControl, INotifyPropertyChanged
    {
        private string srcImg; //img source

        // Define a delegate (use for execute custome method)
        public delegate void ActionDelegate();
        // Define an event based on the delegate
        public event ActionDelegate OnAction;

        public string SrcImg
        {
            get { return srcImg; }
            set 
            { 
                srcImg = value;
                ImageSource imageSource = LoadImage(srcImg);
                iconBTN.Source = imageSource;

            }
        }

        private string txtContent;

        public event PropertyChangedEventHandler PropertyChanged;

        public string TxtContent
        {
            get { return txtContent; }
            set { 
                txtContent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TxtContent")); //use for auto update change binding value
                //txtBTN.Text = txtContent;
            }
        }

        public NavigationBTN()
        {
            DataContext = this;
            InitializeComponent();
        }

        //this function use for execute custom method when user click
        public void ActionButton(object sender, RoutedEventArgs e) 
        {
            // Invoke the event
            OnAction?.Invoke();
        }


        private BitmapImage LoadImage(string uri) //this is how to call image with source
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(uri, UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            return bitmap;
        }

    }
}
