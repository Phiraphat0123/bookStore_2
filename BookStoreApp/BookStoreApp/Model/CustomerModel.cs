using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Model
{
    internal class CustomerModel
    {
        public int customerId { get; set; }
        public string customerName { get; set; }
        public string address { get; set; }
        public string email { get; set; }
    }
}
