using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationAutherization.Models;

namespace WebApplicationAutherization.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        LoginViewModel model = new LoginViewModel();
        public ActionResult Index()
        {

            if(User.Identity.IsAuthenticated)
            {               
              //  string data = dbContext.Users//tbllogins.Where(x => x.Username == username).FirstOrDefault().Role;
                if (User.Identity.Name == "kanbuarasu27@gmail.com")//model.Email
                {
                    ViewBag.Message = "Edit";
                }
                else if(User.Identity.Name == "balaji@gmail.com")
                {
                    ViewBag.Message = "Read";
                }
                else if(User.Identity.Name == "kiru@gmail.com")
                {
                    ViewBag.Message = "Delete";
                }
                else
                {
                    ViewBag.Message = "Create";
                }
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}