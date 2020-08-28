using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using ManoApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace ManoApi.Controllers
{
    public class CartController : ApiController
    {
        private DataModel db = new DataModel();
        private ApplicationUserManager _userManager;

        public CartController()
        {
        }

        public CartController(ApplicationUserManager userManager)
        {
            UserManager = userManager;

        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        
        [Authorize]
        [HttpGet]
        public int GetCart(string userId)
        {        
            var cart = db.carts.Where(x => x.UserId == userId).Select(x=>x.CartId).FirstOrDefault();
            return cart;
        }
    }
}
