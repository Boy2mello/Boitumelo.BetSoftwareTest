using Boitumelo.BetSoftwareWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

namespace Boitumelo.BetSoftwareWeb.AppUtil
{
    public class HttpApiClient
    {
        private static HttpClient _client;
        public static HttpClient GetApiClient()
        {
            if (_client == null)
            {
                var serviceUrl = ConfigurationManager.AppSettings["ServiceUrl"];
                var token = GetToken(serviceUrl);

                if (token != "")
                {
                    _client = Method_Headers(token, serviceUrl);
                }
            }
            return _client;
        }

        private static HttpClient Method_Headers(string accessToken, string endpointURL)
        {
            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = false };
            HttpClient client = new HttpClient(handler);

            client.BaseAddress = new Uri(endpointURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

            return client;
        }

        private static string GetToken(string serviceUrl)
        {
            string content = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serviceUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var credentialsJson = (new JavaScriptSerializer()).Serialize(
                    new TokenCredentialsModel()
                    {
                        Username = ConfigurationManager.AppSettings["ServiceUsername"],// "boy2mello@gmail.com", 
                        Password = ConfigurationManager.AppSettings["ServicePassword"] //"Password123"                              
                    }
                    );

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Uri.EscapeUriString(client.BaseAddress.ToString()));
                request.Content = new StringContent(@credentialsJson, Encoding.UTF8, "application/json");
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                request.Method = HttpMethod.Post;

                HttpResponseMessage responsePost = client.PostAsync("security/login", request.Content).Result;
                if (responsePost.IsSuccessStatusCode)
                {
                    using (StreamReader stream = new StreamReader(responsePost.Content.ReadAsStreamAsync().Result, System.Text.Encoding.GetEncoding("utf-8")))
                    {
                        content = stream.ReadToEnd();
                    }
                }
            }
            return content;
        }
    }
}