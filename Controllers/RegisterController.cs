using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Globalization;
using System.Data;
using System.Data.Entity;
using System.Net.Mail;
using System.Web.Mvc.Html;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RegisterController : Controller
    {
        UserEntities db = new UserEntities();
        // GET: /Register/
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SetDataInDataBase(User model)
        {
            User tbl = new User();
            tbl.Username = model.Username;
            tbl.Password = model.Password;
            db.Users.Add(tbl);
            db.SaveChanges();
            return View();
        }

        public ActionResult ShowDataBaseForUser()
        {
            var item = db.Users.ToList();
            return View(item);
        }

        public ActionResult Delete(int id)
        {
            var item = db.Users.FirstOrDefault(x => x.UserID == id);
            if (item != null)
            {
                db.Users.Remove(item);
                db.SaveChanges();
            }

            var item2 = db.Users.ToList();
            return View("ShowDataBaseForUser", item2);
        }

        public ActionResult Edit(int id)
        {
            var item = db.Users.Where(x => x.UserID == id).First();
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(User model)
        {

            using (UserEntities db = new UserEntities())
            {
                var item = db.Users.Where(x => x.UserID == model.UserID).First();
                item.Username = model.Username;
                item.Firstname = model.Firstname;
                item.Lastname = model.Lastname;
                item.Email = model.Email;
                item.Password = model.Password;


                db.SaveChanges();
                var item2 = db.Users.ToList();

           
                ViewBag.SuccessMessage = "Successful";
                return View("ShowDataBaseForUser", item2);

                
            }

                
        }



    }
}