using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreApplication.Models
{
    public class OrderItemModel
    {
        public int orderID { get; set; }
        public int orderItemID { get; set; }
        public int productID {get; set;}
        public int noOfProducts { get; set; }

    }
}
