using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using OpenSalary.Web.Core;
using OpenSalary.Web.Core.Entities;
using OpenSalary.Web.Models;
using OpenSalary.Web.Models.ViewModels;

namespace OpenSalary.Web.Controllers {
    public class HomeController : Controller {
        
        public ActionResult Index(string name, string sort)
        {
            
            if (string.IsNullOrEmpty(name)) {
                //Show compilation view
                var viewModel = new CompilationViewModel();                
                using (var session = DataStore.Get().OpenSession()) {
                    viewModel.AllEmployees = session.Query<User>().ToList();
                    viewModel.CurrentSortBy = sort;
                    if (string.IsNullOrEmpty(sort)) {
                        viewModel.AllEmployees =
                            viewModel.AllEmployees.OrderByDescending(
                                x => x.CurrentJudgment.Judgment.Sum(j => (int) j.Value)).ToList();
                    } else {
                        var category = (JudgmentCategory) Enum.Parse(typeof (JudgmentCategory), sort, true);
                        viewModel.AllEmployees =
                            viewModel.AllEmployees.OrderByDescending(
                                x =>
                                    x.CurrentJudgment.Judgment.ContainsKey(category)
                                        ? x.CurrentJudgment.Judgment[category]
                                        : 0).ToList();
                    }
                }
                return View("Compilation", viewModel);
            }

            using (var session = DataStore.Get().OpenSession()) {
                var user = session.Query<User>().FirstOrDefault(x => x.UserName.Equals(name));
                if (user == null) {
                    return View("NewUser", new User {UserName = name});
                }
                var isAuthenticated = IsAuthenticated(user);
                if (isAuthenticated) {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("sv-SE");
                    var viewModel = new JudgmentViewModel {
                                                              CurrentUser = user,
                                                              IsAuthenticated = isAuthenticated
                                                          };
                    return View("Index", viewModel);
                }
            }
            return RedirectToAction("Index", "Authentication", new { name = name });
        }        

        [HttpPost]
        public ActionResult ToggleJudgment(string category, string level, string currentUser) {
            var judgmentCategory = (JudgmentCategory) Enum.Parse(typeof (JudgmentCategory), category, true);
            var judgmentLevel = (JudgmentLevel)Enum.Parse(typeof(JudgmentLevel), level, true);
            
                using (var session = DataStore.Get().OpenSession()) {
                    var user = session.Query<User>().FirstOrDefault(x => x.UserName.Equals(currentUser));
                    if (user != null && IsAuthenticated(user)) {
                        if (user.CurrentJudgment.Judgment.ContainsKey(judgmentCategory)) {
                            user.CurrentJudgment.Judgment[judgmentCategory] = judgmentLevel;
                        } else {
                            user.CurrentJudgment.Judgment.Add(judgmentCategory, judgmentLevel);
                        }
                        session.SaveChanges();
                        return new HttpStatusCodeResult(HttpStatusCode.OK);
                    }
                }                                
            
            return new HttpStatusCodeResult(HttpStatusCode.Forbidden);            
        }

        [HttpPost]
        public ActionResult UpdateFreeMotivation(string text, string currentUser) {
            using (var session = DataStore.Get().OpenSession()) {
                var user = session.Query<User>().FirstOrDefault(x => x.UserName.Equals(currentUser));
                if (user != null && IsAuthenticated(user)) {
                    user.CurrentJudgment.FreeMotivation = text;
                    session.SaveChanges();
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
        }

        protected bool IsAuthenticated(User user)
        {
            if (Request.Cookies["AuthID"] != null)
            {
                var authId = Request.Cookies["AuthID"].Value;
                if (authId == user.AuthID)
                {
                    return true;
                }
            }
            return false;
        }
        
        [HttpPost]
        public ActionResult NewUser(FormCollection formCollection)
        {
            var userName = formCollection.GetValue("login-userName").AttemptedValue;
            var name = formCollection.GetValue("login-name").AttemptedValue;
            var pwd = formCollection.GetValue("login-pwd").AttemptedValue;

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(pwd)) {
                User user;
                using (var session = DataStore.Get().OpenSession()) {
                    user = new User {
                                        UserName = userName.ToLower(),
                                        Name = name,
                                        AuthID = Guid.NewGuid().ToString(),
                                        CurrentJudgment = new JudgmentModel()
                                    };
                    user.SetPassword(pwd);

                    session.Store(user);
                    session.SaveChanges();
                }

                var cookie = new HttpCookie("AuthID");
                cookie.Value = user.AuthID;
                cookie.Expires = new DateTime(2020, 12, 31);
                Response.Cookies.Add(cookie);

            }
            return RedirectToAction("Index", new { name = userName });
        }        
    }


}