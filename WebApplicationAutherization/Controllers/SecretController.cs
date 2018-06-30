using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationAutherization.Controllers
{
    [Authorize]
    public class SecretController : Controller
    {
        // GET: Secret

        //[Authorize(Users = "anbu, balaji")]
        //[Authorize(Roles = "canEdit, admin, member")]
        [Authorize(Users = "kanbuarasu27@gmail.com, balaji@gmail.com")]
        public string Secret()
        {
            return "I am Screct Action... Only Local Registered user can see me...";
        }

        [AllowAnonymous]
        public string Public()
        {
            return "I am a Public action... Everyone can see me...";
        }
    }
}