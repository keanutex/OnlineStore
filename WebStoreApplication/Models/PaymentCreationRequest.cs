using System.Collections.Generic;

namespace WebStoreApplication.Models
{
    public class PaymentCreationRequest
    {
        public string intent;
        public Payer payer;
        public List<Transactions> transactions;
        public Redirect_Urls redirect_urls;
    }
    public class Payer
    {
        public string payment_method;
    }
    public class Transactions
    {
        public Amount amount;
        public PaymentOption payment_options;
    }
    public class Amount
    {
        public string total;
        public string currency;
    }
    public class PaymentOption
    {
        public string allowed_payment_method;
    }
    public class Redirect_Urls
    {
        public string return_url;
        public string cancel_url;
    }
}