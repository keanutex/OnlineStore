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
        public async Task<string> getToken()
        {
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
            response.EnsureSuccessStatusCode();
            string resp = await response.Content.ReadAsStringAsync();
            PayPalAccessToken jsonResp = JsonSerializer.Deserialize<PayPalAccessToken>(resp);
            //Console.WriteLine(resp);
            return jsonResp.access_token;
        }

        public async Task<string> createPayment(string total)
        {
            // Task<string> token = getToken();
            // Console.WriteLine(token.ToString());

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
            response.EnsureSuccessStatusCode();
            string resp = await response.Content.ReadAsStringAsync();
            PayPalAccessToken jsonResp = JsonSerializer.Deserialize<PayPalAccessToken>(resp);
            PayPalServerContext.payPalAccessToken = jsonResp.access_token;


            //Console.WriteLine(PayPalServerContext.GetPayPalAccessToken());
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.sandbox.paypal.com/v1/payments/payment");
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jsonResp.access_token);
            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            request.Content = new StringContent("{   \"intent\": \"sale\",   \"payer\": {     \"payment_method\": \"paypal\"   },   \"transactions\": [     {       \"amount\": {         \"total\": \"" + total + "\",         \"currency\": \"USD\"       },       \"payment_options\": {         \"allowed_payment_method\": \"INSTANT_FUNDING_SOURCE\"       }     }   ],   \"redirect_urls\": {     \"return_url\": \"https://example.com\",     \"cancel_url\": \"https://example.com\"   } }", Encoding.UTF8, "application/json");
            response =  await PayPalServerContext.GetClient().SendAsync(request);
            response.EnsureSuccessStatusCode();
            resp = await response.Content.ReadAsStringAsync();
            JObject joResponse = JObject.Parse(resp);
            JArray array= (JArray)joResponse["links"];
            JObject ojObject = (JObject)array[1];
            PayPalServerContext.payPalExecuteURL = ((JObject)array[2])["href"].ToString();
            Console.WriteLine(resp);
            Console.WriteLine(jsonResp.access_token);
            Console.WriteLine(ojObject["href"]);
            return ojObject["href"].ToString();
        }

        public async void ExecutePayment(string payerid)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, PayPalServerContext.payPalExecuteURL);
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", PayPalServerContext.payPalAccessToken);
            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            request.Content = new StringContent("{\"payer_id\":\"" + payerid + "\"}", Encoding.UTF8, "application/json");
            HttpResponseMessage response =  await PayPalServerContext.GetClient().SendAsync(request);
            response.EnsureSuccessStatusCode();
            string resp = await response.Content.ReadAsStringAsync();
            Console.WriteLine(resp);
        }
    }
}