using System.Net.Http;
namespace WebStoreApplication.Models
{
    public static class PayPalServerContext
    {
        private static HttpClient client;
        public static string payPalAccessToken {get; set;}
        public static string payPalExecuteURL {get;set;}
        static PayPalServerContext ()
        {
            // client = new HttpClient();
            payPalAccessToken = "";
            payPalExecuteURL = "";
        }
        public static HttpClient GetClient()
        {
            return client;
        }
        public static void InitialiseClient()
        {
            client = new HttpClient();
        }
    }
}