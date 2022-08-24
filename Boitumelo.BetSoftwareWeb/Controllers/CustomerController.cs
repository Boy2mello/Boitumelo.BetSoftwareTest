using Boitumelo.BetSoftwareWeb.AppUtil;
using Boitumelo.BetSoftwareWeb.Models;
using Boitumelo.BetSoftwareWeb.Repository;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Boitumelo.BetSoftwareWeb.Controllers
{
    public class CustomerController : Controller
    {
        private ILogger _log;
       
        readonly IUserRepository _userRepository;

        public CustomerController(IUserRepository userRepository, ILogger log)
        {
            this._userRepository = userRepository;
            this._log = log;
        }
        [Authorize]      
        public async Task<ActionResult> Index() 
        {           
            var user = await _userRepository.GetCurrentUserProfile((System.Security.Claims.ClaimsIdentity)User.Identity);
            return user.Item1 != null ? View(user.Item1) : View(new UserSessionProfileModel());
        }

        [HttpPost]
        [Authorize]       
        public async Task<ActionResult> UpdateUser(UserModel user)
        {
            if (ModelState.IsValid)
            {
                await _userRepository.UpdateUser(user);
            }
            return RedirectToAction("Index", "Customer");
        }
    }
}
