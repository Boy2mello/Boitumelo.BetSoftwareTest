using Boitumelo.BetSoftwareWeb.AppUtil;
using Boitumelo.BetSoftwareWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace Boitumelo.BetSoftwareWeb.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _client;
        public UserRepository()
        {
            _client = HttpApiClient.GetApiClient();
        }

        public async Task<Tuple<UserModel>> UpdateUser(UserModel user)
        {
            try
            {
                HttpResponseMessage response = await _client.PostAsync($"api/User",
                        new StringContent(JsonConvert.SerializeObject(user), System.Text.Encoding.Unicode, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        var obj = JsonConvert.DeserializeObject<UserModel>(content);
                        return new Tuple<UserModel>(obj);
                    }
                }
                return new Tuple<UserModel>(null);
            }
            catch (Exception ex)
            {
                return new Tuple<UserModel>(null);
            }
        }

        public async Task<Tuple<bool>> InitUserProfile(System.Security.Claims.ClaimsIdentity claims)
        {
            var names = claims?.FindFirst("name")?.Value.Split(' ');
            UserSessionProfileModel profile = new UserSessionProfileModel()
            {
                Firstname = names[0] != null ? names[0] : "Name Not Provided",
                Lastname = names[1] != null ? names[1] : "Lastname Not Provided",
                Email = claims?.FindFirst("preferred_username")?.Value,
                Subject = claims?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value,
                TenantId = claims?.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid")?.Value
            };

            var currentUserContactDetails = await GetUserByEmail(profile.Email);
            profile.ProfileId = currentUserContactDetails.Item1 != null ? currentUserContactDetails.Item1.UserID : 0;

            Tuple<UserModel> currentUser;
            if (profile.ProfileId > 0)
            {
                currentUser = await GetUser(profile.ProfileId);
            }
            else
            {
                UserModel user = new UserModel()
                {
                    Id = profile.ProfileId,
                    FirstName = profile.Firstname,
                    LastName = profile.Lastname
                };
                var addCustomer = await InsertUser(user);
            }

            return new Tuple<bool>(true);
        }

        public async Task<Tuple<UserSessionProfileModel>> GetCurrentUserProfile(System.Security.Claims.ClaimsIdentity claims)
        {
            //HttpSessionState 
            var names = claims?.FindFirst("name")?.Value.Split(' ');
            UserSessionProfileModel profile = new UserSessionProfileModel()
            {
                Firstname = names[0] != null ? names[0] : "Name Not Provided",
                Lastname = names[1] != null ? names[1] : "Lastname Not Provided",
                Email = claims?.FindFirst("preferred_username")?.Value,
                Subject = claims?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value,
                TenantId = claims?.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid")?.Value
            };

            var currentUserContactDetails = await GetUserByEmail(profile.Email);
            profile.ProfileId = currentUserContactDetails.Item1 != null ? currentUserContactDetails.Item1.UserID : 0;

            Tuple<UserModel> currentUser;
            if (profile.ProfileId > 0)
            {
                currentUser = await GetUser(profile.ProfileId);
            }
            else
            {
                UserModel user = new UserModel()
                {
                    Id = profile.ProfileId,
                    FirstName = profile.Firstname,
                    LastName = profile.Lastname
                };
                currentUser = await InsertUser(user);
            }
            return new Tuple<UserSessionProfileModel> (profile);
        }

        public async Task<Tuple<UserModel>> InsertUser(UserModel userModel)
        {
            try
            {
                HttpResponseMessage response = await _client.PostAsync($"api/User",
                        new StringContent(JsonConvert.SerializeObject(userModel), System.Text.Encoding.Unicode, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        var obj = JsonConvert.DeserializeObject<UserModel>(content);
                        return new Tuple<UserModel>(obj);
                    }
                }
                return new Tuple<UserModel>(null);
            }
            catch (Exception ex)
            {
                return new Tuple<UserModel>(null);
            }
        }

        private async Task<Tuple<ContactDetailModel>> GetUserByEmail(string email)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync($"api/ContactDetail/email/{email}");
                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(responseData))
                    {
                        var model = JsonConvert.DeserializeObject<ContactDetailModel>(responseData);
                        return new Tuple<ContactDetailModel>(model);
                    }
                }
                return new Tuple<ContactDetailModel>(null);
            }
            catch (Exception ex)
            {
                return new Tuple<ContactDetailModel>(null);
            }
        }

        public async Task<Tuple<UserModel>> GetUser(int userId)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync($"api/User/{userId}");
                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(responseData))
                    {
                        var model = JsonConvert.DeserializeObject<UserModel>(responseData);
                        return new Tuple<UserModel>(model);
                    }
                }
                return new Tuple<UserModel>(null);
            }
            catch (Exception ex)
            {
                return new Tuple<UserModel>(null);
            }
        }
    }
}