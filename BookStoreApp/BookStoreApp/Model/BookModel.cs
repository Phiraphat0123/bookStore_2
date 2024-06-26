using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Model
{
    internal class BookModel
    {
        public int ISBN { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double price { get; set; }
    }
}
