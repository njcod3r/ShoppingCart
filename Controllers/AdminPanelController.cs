using MagicCard.Models.ViewModels;
using MagicCard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace MagicCard.Controllers
{
    public class AdminPanelController : Controller
    {
        AdminPanelServices _AdminPanelServices = new AdminPanelServices();
        // GET: AdminPanel
        public ActionResult Login()
        {
            //UserAuth userAuth = new UserAuth();           
            //HttpCookie cookie = HttpContext.Request.Cookies.Get("UserName");           
            //HttpCookie cookie2 = HttpContext.Request.Cookies.Get("Password");
            //userAuth.username = cookie.Value;
            //userAuth.password = cookie2.Value;
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Clear();           
            return View("Login");
        }

        public ActionResult Admin()
        {
            if (Session["User"] == null)
            {
                return View("Login");
            }
            return View();
        }

        public ActionResult ContactUs()
        {
            if (Session["User"] == null)
            {
                return View("Login");
            }
            return View();
        }

        public ActionResult Category()
        {
            if (Session["User"] == null)
            {
                return View("Login");
            }
            return View();
        }

        public ActionResult UserAuthentication(UserAuth userAuth)
        {
            string username = userAuth.username;
            string password = userAuth.password;
            bool rememberMe = userAuth.rememberMe;

            Usr_Users user = new Usr_Users();
            if (userLoginValidation(username, password))
                user = _AdminPanelServices.getAuthentication(username, password);
            else
                user = null;

            if (user == null)
            {
                Session["User"] = null;
                return new HttpStatusCodeResult(401, "Authentication Error");
            }
           
           // int timeout = rememberMe ? 525600 : 30; // Timeout in minutes, 525600 = 365 days.

            //if (rememberMe)
            //{
            //    HttpCookie cookie = new HttpCookie("UserName", username);
            //    HttpContext.Response.Cookies.Remove("UserName");
            //    HttpContext.Response.SetCookie(cookie);

            //    HttpCookie cookie2 = new HttpCookie("Password", password);
            //    HttpContext.Response.Cookies.Remove("Password");
            //    HttpContext.Response.SetCookie(cookie2);
            //}
            

            //var ticket = new FormsAuthenticationTicket(username, rememberMe, timeout);
            //string encrypted = FormsAuthentication.Encrypt(ticket);
            //var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
            //cookie.Expires = System.DateTime.Now.AddMinutes(timeout);// Not my line
            //Response.Cookies.Add(cookie);
           
            //ticket = new FormsAuthenticationTicket(password, rememberMe, timeout);
            //encrypted = FormsAuthentication.Encrypt(ticket);
            //cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
            //cookie.Expires = System.DateTime.Now.AddMinutes(timeout);// Not my line
            //Response.Cookies.Add(cookie);

            Session["User"] = user;
            Session["userName"] = string.Format ("{0} {1}",user.UserFirstName,user.UserLastName);
            Session["userImage"] = user.UserImage;
            
            return Json(new JavaScriptSerializer().Serialize(new Usr_Users 
            { UserFirstName = user.UserFirstName, UserLastName = user.UserLastName, UserImage = user.UserImage })
            , JsonRequestBehavior.AllowGet);
        }

        private bool userLoginValidation(string username, string password)
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                isValid = false;
            return isValid;
        }
    }
}