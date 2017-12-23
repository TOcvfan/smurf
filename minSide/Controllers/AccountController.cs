using minSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace minSide.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private SmurfContext sm = new SmurfContext();
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            return View(model);
        }
        // GET: /Account/LogOff
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        // POST: /Account/Register
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model/*, User usermodel*/)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user

                try
                {
                    MembershipUser NewUser = Membership.CreateUser(model.UserName, model.Password, model.Email);
                    //Log the user on with the new account
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    /*using (SmurfContext context = new SmurfContext())
                    {
                        User user = new User
                        {
                            FName = usermodel.FName,
                            LName = usermodel.LName,
                            Role = usermodel.Role,
                            Phone = usermodel.Phone,
                            Status = usermodel.Status,
                            Gender = usermodel.Gender,
                            Age = usermodel.Age
                        };
                        context.UserInfo.Add(user);
                        context.SaveChanges();
                    }*/
                    return RedirectToAction("index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("Registration Error", "Registration error: " + e.StatusCode.ToString());
                }
            }

            return View(model);
        }
    }
}