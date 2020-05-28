using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreApplication.Models
{
    public class OrdersModel
    {
        public int orderID { get; set; }
        public int userID { get; set; }
        public int orderStatusID { get; set; }
    }
}
