using _3PalmsSecurity.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace _3PalmsSecurity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        [System.Web.Mvc.HttpPost]
        public ActionResult ContactUs(ContactUsViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        string mailAccount = WebConfigurationManager.AppSettings["mailAccount"];
                        //string mailPassword = WebConfigurationManager.AppSettings["mailPassword"];
                        //string smtpServer = WebConfigurationManager.AppSettings["smtpServer"];
                        //int smtpPort = Convert.ToInt32(WebConfigurationManager.AppSettings["smtpPort"]);

                        mail.From = new MailAddress(mailAccount);
                        mail.To.Add(mailAccount);
                        mail.Subject = vm.Company + " - " + vm.Email;
                        mail.Body = "The following company has submitted a request for contact.<br />" +
                            "Name: " + vm.Name + "<br />" +
                            "Company: " + vm.Company + "<br />" +
                            "Email: " + vm.Email + "<br />" +
                            "Phone: " + vm.Phone + "<br />";
                        mail.IsBodyHtml = true;

                        SmtpClient smtp = new SmtpClient();
                        smtp.Send(mail);

                        //using (SmtpClient smtp = new SmtpClient())
                        //{
                        //    smtp.Credentials = new NetworkCredential(mailAccount, mailPassword);
                        //    smtp.EnableSsl = true;
                        //    smtp.Send(mail);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                // Something went wrong
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.ToString());
            }


            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}