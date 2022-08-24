
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Script.Serialization;
//using System.Xml;

//namespace Boitumelo.BetSoftwareWeb.AppUtil
//{
//    public class HttpApiClient
//    {
//        private string serviceUrl;
//        private int servicePort;
//        private string clientid;
//        private string clientsecret;
//        private string baseUrl;
//        private string accessTokenUrl;        
//        private string responseMessage = "";
//        private string responseStatus = "";
//        public HttpApiClient()
//        {
//            this.serviceUrl = ConfigurationManager.AppSettings["ServiceUrl"];
//            this.servicePort = int.Parse(ConfigurationManager.AppSettings["ServicePort"]);

//            this.clientid = ConfigurationManager.AppSettings["ClientId"];
//            this.clientsecret = ConfigurationManager.AppSettings["ClientSecret"];

//            this.baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
//            this.accessTokenUrl = ConfigurationManager.AppSettings["AccessTokemUrl"];
//        }

//        public string ResponseMessage { get { return string.IsNullOrEmpty(responseMessage) ? "" : responseMessage; } set { responseMessage = value; } }

//        public string ResponseStatus { get { return string.IsNullOrEmpty(responseStatus) ? "" : responseStatus; } set { responseStatus = value; } }



//        public string Invoke(string message)
//        {
           
//            try
//            {
                   
//                    var serializer = new JavaScriptSerializer();
//                    string content = GetAuthorizeToken();
//                    var tokenObj = serializer.Deserialize<Token>(content);


//                    if (tokenObj.access_token != "")
//                    {
//                        var requestMessage = serializer.Serialize(hl7MessageObj);

//                        HttpClient client = Method_Headers(tokenObj.access_token, serviceUrl);
//                        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Uri.EscapeUriString(client.BaseAddress.ToString()));
//                        request.Content = new StringContent(@requestMessage, Encoding.UTF8, "application/json");
//                        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
//                        request.Method = HttpMethod.Post;

//                        ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
//                        HttpResponseMessage tokenResponse = client.PostAsync(Uri.EscapeUriString(client.BaseAddress.ToString()), request.Content).Result;
//                        this.ServiceHttpResponseMessage = tokenResponse;

//                        using (StreamReader stream = new StreamReader(tokenResponse.Content.ReadAsStreamAsync().Result, System.Text.Encoding.GetEncoding("utf-8")))
//                        {
//                            content = stream.ReadToEnd();
//                        }

//                        return content;
//                    }
                
//            }
//            catch (Exception ex)
//            {
//                var errorMessage = string.Format("Invoke::Error : {0} \n StackTrace : {1}", ex.Message, ex.StackTrace);
//                System.Diagnostics.EventLog.WriteEntry("BetSoftware ", errorMessage, System.Diagnostics.EventLogEntryType.Error);               
//            }

//            return null;
//        }


//        private HttpClient Method_Headers(string accessToken, string endpointURL)
//        {
//            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = false };
//            HttpClient client = new HttpClient(handler);

//            client.BaseAddress = new Uri(endpointURL);
//            client.DefaultRequestHeaders.Accept.Clear();
//            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
//            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));

//            return client;
//        }

//        private string GetAuthorizeToken()
//        {
//            // Initialization.  
//            string content = string.Empty;

//            // Posting.  
//            using (var client = HeadersForAccessTokenGenerate())
//            {
//                // Setting Base address.  
//                client.BaseAddress = new Uri(this.accessTokenUrl);
//                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//                string body = "grant_type=client_credentials&scope=public";
//                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
//                request.Content = new StringContent(body,
//                                                    Encoding.UTF8,
//                                                    "application/json");

//                List<KeyValuePair<string, string>> allIputParams = new List<KeyValuePair<string, string>>();
//                allIputParams.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
//                allIputParams.Add(new KeyValuePair<string, string>("scope", "user/*.write"));
//                allIputParams.Add(new KeyValuePair<string, string>("client_id", this.clientid));
//                allIputParams.Add(new KeyValuePair<string, string>("client_secret", this.clientsecret));

//                HttpContent requestParams = new FormUrlEncodedContent(allIputParams);
//                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
//                HttpResponseMessage response = client.PostAsync(this.accessTokenUrl, requestParams).Result;

//                // Verification  
//                if (response.IsSuccessStatusCode)
//                {
//                    using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result, System.Text.Encoding.GetEncoding("utf-8")))
//                    {
//                        content = stream.ReadToEnd();
//                    }
//                    return content;
//                }               
//            }
//            return content;
//        }


//        private HttpClient HeadersForAccessTokenGenerate()
//        {
//            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = false };
//            HttpClient client = new HttpClient(handler);

//            client.BaseAddress = new Uri(this.baseUrl);
//            client.DefaultRequestHeaders.Accept.Clear();
//            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//            //client.DefaultRequestHeaders.Add("apikey", apikey);
//            client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(
//                     System.Text.ASCIIEncoding.ASCII.GetBytes(
//                        $"{this.clientid}:{this.clientsecret}")));

//            return client;
//        }

//        public HttpResponseMessage ServiceHttpResponseMessage { get; set; }

//        public HttpWebResponse ServiceWebResponseMessage { get; set; }
//    }

//    public class Token
//    {
//        public string token_type { get; set; }
//        public string access_token { get; set; }
//    }

//}