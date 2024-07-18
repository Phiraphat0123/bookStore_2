using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Model
{
    internal class SalesModel
    {
        public int salesId { get; set; }
        public int ISBN { get; set; }
        public int customerId {  get; set; }
        public int quantity { get; set; }
        public double totalPrice { get; set; }

    }
}
