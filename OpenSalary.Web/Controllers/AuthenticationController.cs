using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenSalary.Web.Core;
using OpenSalary.Web.Models;

namespace OpenSalary.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/

        public ActionResult Index(string name)
        {
            
            return View(new User {UserName = name});
        }
        
        [HttpPost]
        public ActionResult Login(FormCollection formCollection)
        {
            var userName = formCollection.GetValue("login-userName").AttemptedValue;
            var pwd = formCollection.GetValue("login-pwd").AttemptedValue;

            User user;
            using (var session = DataStore.Get().OpenSession()) {
                user = session.Query<User>().FirstOrDefault(x => x.UserName.Equals(userName));
            }
            if (user == null || !user.ValidatePassword(pwd))
            {
                return RedirectToAction("Index", new { name = userName });
            }
            
            var cookie = new HttpCookie("AuthID");
            cookie.Value = user.AuthID;
            cookie.Expires = new DateTime(2020, 12, 31);
            Response.Cookies.Add(cookie);
            

            return RedirectToAction("Index", "Home", new { name = userName });
        }

    }
}
