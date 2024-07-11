using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BookStoreApp.Model
{
    internal class ImageLoading
    {
        public static BitmapImage GetImage(string uri) //this is how to call image with source
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(uri, UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            return bitmap;
        }

    }

}
