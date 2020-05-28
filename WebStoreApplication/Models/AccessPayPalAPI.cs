using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace WebStoreApplication.Models
{
    public class AccessPayPalAPI: IAccessPayPalAPI
    {
        public async Task<string> GetToken()
        {
            // GET PAYPAL ACCESS TOKEN
            PayPalServerContext.GetClient().BaseAddress = new Uri("https://api.sandbox.paypal.com/v1/oauth2/token/");
            PayPalServerContext.GetClient().DefaultRequestHeaders.Accept.Clear();
            PayPalServerContext.GetClient().DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            PayPalServerContext.GetClient().DefaultRequestHeaders.Add("Accept-Language", "en-US");
            var byteArray = Encoding.ASCII.GetBytes("AcCrUCLNMTKYfwWXOmqR5ADBtxL6Sjbv8_UEIcE2xNYdT2j-yyXIGwWw-WOF3d5qFLOCZkJr4VibdDYR:ENHpzB1JKVB-BxdrFSsTb_dyYhXag39vkmi9TOxo82CF97EmdsBvrRtAaw8Rvp0fBlPxnx2nZceRqi0f");
            PayPalServerContext.GetClient().DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var a = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("grant_type","client_credentials")
                };
            HttpContent content = new FormUrlEncodedContent(a);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            HttpResponseMessage response =  await PayPalServerContext.GetClient().PostAsync("", content);
            if (response.IsSuccessStatusCode)
            {
                // Handle success
                string resp = await response.Content.ReadAsStringAsync();
                PayPalAccessToken jsonResp = JsonSerializer.Deserialize<PayPalAccessToken>(resp);
                Console.WriteLine("GetToken():\t" + resp);
                return jsonResp.access_token;
            }
            else
            {
                // Handle failure
                return null;
            }
        }

        public async Task<string> CreatePayment(string total)
        {
            // GET PAYPAL ACCESS TOKEN
            PayPalServerContext.InitialiseClient();
            PayPalServerContext.GetClient().BaseAddress = new Uri("https://api.sandbox.paypal.com/v1/oauth2/token/");
            PayPalServerContext.GetClient().DefaultRequestHeaders.Accept.Clear();
            PayPalServerContext.GetClient().DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            PayPalServerContext.GetClient().DefaultRequestHeaders.Add("Accept-Language", "en-US");
            var byteArray = Encoding.ASCII.GetBytes("AcCrUCLNMTKYfwWXOmqR5ADBtxL6Sjbv8_UEIcE2xNYdT2j-yyXIGwWw-WOF3d5qFLOCZkJr4VibdDYR:ENHpzB1JKVB-BxdrFSsTb_dyYhXag39vkmi9TOxo82CF97EmdsBvrRtAaw8Rvp0fBlPxnx2nZceRqi0f");
            PayPalServerContext.GetClient().DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var a = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("grant_type","client_credentials")
                };
            HttpContent content = new FormUrlEncodedContent(a);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            HttpResponseMessage response =  await PayPalServerContext.GetClient().PostAsync("", content);
            
            if (!response.IsSuccessStatusCode)
            {
                // Handle failure
                return null;
            }

            string resp = await response.Content.ReadAsStringAsync();
            PayPalAccessToken jsonResp = JsonSerializer.Deserialize<PayPalAccessToken>(resp);
            Console.WriteLine("Token in CreatePayment():\t" + resp);
            PayPalServerContext.payPalAccessToken = jsonResp.access_token;

            // CREATE PAYPAL PAYMENT
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.sandbox.paypal.com/v1/payments/payment");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jsonResp.access_token);
            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            request.Content = new StringContent("{   \"intent\": \"sale\",   \"payer\": {     \"payment_method\": \"paypal\"   },   \"transactions\": [     {       \"amount\": {         \"total\": \"" + total + "\",         \"currency\": \"USD\"       },       \"payment_options\": {         \"allowed_payment_method\": \"INSTANT_FUNDING_SOURCE\"       }     }   ],   \"redirect_urls\": {     \"return_url\": \"https://localhost:5001/\",     \"cancel_url\": \"https://localhost:5001/\"   } }", Encoding.UTF8, "application/json");
            response =  await PayPalServerContext.GetClient().SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                // Handle failure
                return null;
            }
            resp = await response.Content.ReadAsStringAsync();
            JObject jsonResponse = JObject.Parse(resp);
            JArray linksArray = (JArray)jsonResponse["links"];
            JObject approve_URL = (JObject)linksArray[1];
            PayPalServerContext.payPalExecuteURL = ((JObject)linksArray[2])["href"].ToString();
            Console.WriteLine("CreatePayment() Response:\t" + resp);
            Console.WriteLine("Approve URL:\t" + approve_URL["href"]);
            return approve_URL["href"].ToString();
        }

        public async Task<String> ExecutePayment(string payerid)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, PayPalServerContext.payPalExecuteURL);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", PayPalServerContext.payPalAccessToken);
            request.Content = new StringContent("{\"payer_id\":\"" + payerid + "\"}", Encoding.UTF8, "application/json");
            HttpResponseMessage response =  await PayPalServerContext.GetClient().SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                // Handle failure
                return null;
            }
            string resp = await response.Content.ReadAsStringAsync();
            Console.WriteLine("ExecutePayment() Response:\t" + resp);
            PayPalServerContext.GetClient().Dispose();
            return "";
        }
    }
}