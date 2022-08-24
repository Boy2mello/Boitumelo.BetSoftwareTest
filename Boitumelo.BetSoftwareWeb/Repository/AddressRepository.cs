using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Boitumelo.BetSoftwareWeb.AppUtil;
using Boitumelo.BetSoftwareWeb.Models;
using Newtonsoft.Json;

namespace Boitumelo.BetSoftwareWeb.Repository
{
    public class AddressRepository
    {

        private readonly HttpClient _client;
        public AddressRepository()
        {
            _client = HttpApiClient.GetApiClient();
        }    


        protected async Task<Tuple<AddressModel>>  GetAddresses()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync($"/Address");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        var customer = JsonConvert.DeserializeObject<AddressModel>(content);
                        return new Tuple<AddressModel>(customer);
                    }
                }
                return new Tuple<AddressModel>(null);
            }
            catch (Exception ex)
            {
                return new Tuple<AddressModel>(null);
            }
        }

    protected async Task<Tuple<AddressModel>> UpdateAddress(AddressModel model)
        {
            try
            {
                HttpResponseMessage response = await _client.PostAsync($"/Address",
                        new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.Unicode, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {                        
                        return new Tuple<AddressModel>(
                            JsonConvert.DeserializeObject<AddressModel>(content)
                            );
                    }
                }
                return new Tuple<AddressModel>(null);
            }
            catch (Exception ex)
            {
                return new Tuple<AddressModel>(null);
            }
        }

        //protected static async Task<AddressModel> DeleteAddress(int id)
        //{
            
        //}
    }
}