using _3PalmsSecurity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
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

        [HttpPost]
        public ActionResult ContactUs(ContactUsViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        string mailAccount = WebConfigurationManager.AppSettings["mailAccount"];
                        string mailPassword = WebConfigurationManager.AppSettings["mailPassword"];
                        string smtpServer = WebConfigurationManager.AppSettings["smtpServer"];
                        int smtpPort = Convert.ToInt32(WebConfigurationManager.AppSettings["smtpPort"]);

                        mail.From = new MailAddress(mailAccount);
                        mail.To.Add(mailAccount);
                        mail.Subject = vm.Company + " - " + vm.Email;
                        mail.Body = "<h1>Hello</h1>";
                        mail.IsBodyHtml = true;

                        using (SmtpClient smtp = new SmtpClient(smtpServer, smtpPort))
                        {
                            smtp.Credentials = new NetworkCredential(mailAccount, mailPassword);
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Something went wrong
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.InnerException.ToString());
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}