using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Globalization;
using WebApplication1.Controllers;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Register(int id = 0)
        {


            User userModel = new User();
            return View(userModel);
        }

        //==============REGISTER===================//
        [HttpPost]


        public ActionResult Register(User userModel, string language)
        {
           // Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
          // Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            using (UserEntities dbModel = new UserEntities())
            {
                if (dbModel.Users.Any(X => X.Username == userModel.Username))
                {
                    ViewBag.DuplicateMessage = "Username already exist.";
                    return View("Register", userModel);
                }

                dbModel.Users.Add(userModel);
                dbModel.SaveChanges();

            }

            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful";
            return View("Register", new User());
        }






        //==============LOGIN===================//
        [HttpGet]
        public ActionResult Login(string language)
        {
          //  Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
          //  Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            return View();
        }


        //==============AFTER LOGIN===================//

        [HttpPost]

        public ActionResult Login(User user, string language)

        {

            using (UserEntities dc = new UserEntities())
            {


                var userDetail = dc.Users.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();
                if (userDetail == null)
                {

                    // User2.LoginError = "Wrong username or password";
                    return View("Login", user);

                }

            

                else
                {
                  
                    
                    if (userDetail.Username == "Admin" && userDetail.Password == "Admin")
                    {

   
                        return RedirectToAction("ShowDataBaseForUser", "Register");
                    }

                  
  
                        Session["Username"] = userDetail.Username;
                        return RedirectToAction("AfterLogin", "User");
                    
                   
                }


            }
        }

        //==============LOG OUT==================//


        public ActionResult Logout(string language)
        {
         //   Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
         //   Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            Session.Abandon();
            return RedirectToAction("Login", "User");
        }

        public ActionResult AfterLogin(string language)
        {
         //  Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
           // Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            return View();
        }



        public ActionResult Varify(string language)
        {
         //   Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
         //   Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            return View();
        }




        //---------------------------------------------------ADMIN-------------------------------//


    }
}











