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
    public class HomeController : Controller
    {
        public ActionResult Change(string language)
        {
            if (language != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            }

            HttpCookie cookie = new HttpCookie(language);
            cookie.Value = language;
            Response.Cookies.Add(cookie);
            return View();
        }





        //  -------------------------------------- HOME --------------------------------------------------- //
        public ActionResult Index(string language)

        {
            if (language != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            }

            HttpCookie cookie = new HttpCookie(language);
            cookie.Value = language;
            Response.Cookies.Add(cookie);
            return View();
        }

        //  -------------------------------------- ABOUT --------------------------------------------------- //


        //Qr code//
        public ActionResult About(string language)
        {
            if (language != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            }

            HttpCookie cookie = new HttpCookie(language);
            cookie.Value = language;
            Response.Cookies.Add(cookie);
            return View();

        }

        //Barcode//

        //  -------------------------------------- ABOUT --------------------------------------------------- //

        public ActionResult aboutus(string language)
        {

            if (language != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            }
            HttpCookie cookie = new HttpCookie(language);
            cookie.Value = language;
            Response.Cookies.Add(cookie);
            return View();

            return View();
        }



        //  -------------------------------------- CONTACT --------------------------------------------------- //

        public ActionResult Contact(string language)
        {

            if (language != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            }

            HttpCookie cookie = new HttpCookie(language);
            cookie.Value = language;
            Response.Cookies.Add(cookie);
            return View();
        }

        //    [HttpPost]
        //    public ActionResult Contact(MailModels model)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var body = new StringBuilder();
        //            body.AppendLine("Name: " + model.Fullname);
        //            body.AppendLine("Subject: " + model.Subject);
        //            body.AppendLine("Phone: " + model.Phone);
        //            body.AppendLine("Email: " + model.Email);
        //           body.AppendLine("Message: " + model.Message);
        //            gmail.SendMail(body.ToString());
        //            ViewBag.Success = true;
        //        }
        //        return View();
        //    }


        [HttpPost]
        public ActionResult Contact(MailModels model)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(model.Email);
                mail.From = new MailAddress("youremailid@gmail.com");
                mail.Subject = model.Subject;

                string userMessage = "";
                userMessage = "<br/>Name :" + model.Fullname;
                userMessage = userMessage + "<br/>Email Id: " + model.Email;
                userMessage = userMessage + "<br/>Phone No: " + model.Phone;
                userMessage = userMessage + "<br/>Message: " + model.Message;
                string Body = "Hi, <br/><br/> A new enquiry by user. Detail is as follows:<br/><br/> " + model.Message + "<br/><br/>Thanks";


                mail.Body = Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                //SMTP Server Address of gmail
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("bcscanerweb@gmail.com", "BC1212312121");
                // Smtp Email ID and Password For authentication
                smtp.EnableSsl = true;
                smtp.Send(mail);
                ViewBag.Message = "Thank you for contacting us.";
            }
            catch
            {
                ViewBag.Message = "Error";
            }

            return View();
        }



        // --------------------------------------- SCAN ------------------------------------------------------//

        public ActionResult Scan(string qrcode, string language)
        {


            if (language != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            }

            HttpCookie cookie = new HttpCookie(language);
            cookie.Value = language;
            Response.Cookies.Add(cookie);
            return View();
        }




        


    }
}