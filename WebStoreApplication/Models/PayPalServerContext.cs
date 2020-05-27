using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;
using System.Text.Json;
namespace WebStoreApplication.Models
{
    public static class PayPalServerContext
    {
        private static HttpClient client;
        public static string payPalAccessToken {get; set;}
        public static string payPalExecuteURL {get;set;}
        static PayPalServerContext ()
        {
            client = new HttpClient();
            payPalAccessToken = "";
            payPalExecuteURL = "";
        }
        public static HttpClient GetClient()
        {
            return client;
        }
    }
}