
using Core.CustomClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using System.Net.Mail;

namespace Inspinia_MVC5.Controllers
{
    public class PagesController : Controller
    {

        public ActionResult SearchResults()
        {
            return View();
        }

        public ActionResult LockScreen()
        {
            return View();
        }

        public ActionResult Invoice()
        {
            return View();
        }

        public ActionResult InvoicePrint()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ErrorLogin(string username, string password)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin(string username, string password)
        {
            //UserServiceClient client = new UserServiceClient();
            //UserView response = client.checkLogin(username, password);

            Core.FakeService.UserService client = new Core.FakeService.UserService();
            UserView response = client.checkLogin(username, password);

            if (response != null)
            {
                ProfileViewList listaProfili = client.GetProfilesByUserId(response.User.ID_USER);
                Session["user"] = response;
                Session["profili"] = listaProfili;
                return RedirectToAction("Dashboard_1", "Dashboards");

            }
            else
            {
                RedirectToAction("Login/ErrorLogin", "Pages");
            }

            return View();
        }

        public ActionResult Login_2()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }


        public ActionResult RegistrationConfirm()
        {
            return View();
        }

        public ActionResult SendMail()
        {
            try
            {

                SmtpClient mySmtpClient = new SmtpClient("my.smtp.exampleserver.net");

                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                System.Net.NetworkCredential basicAuthenticationInfo = new
                   System.Net.NetworkCredential("username", "password");
                mySmtpClient.Credentials = basicAuthenticationInfo;

                // add from,to mailaddresses
                MailAddress from = new MailAddress("test@example.com", "TestFromName");
                MailAddress to = new MailAddress("test2@example.com", "TestToName");
                MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                // add ReplyTo
                MailAddress replyto = new MailAddress("reply@example.com");
                myMail.ReplyToList.Add("");

                // set subject and encoding
                myMail.Subject = "Test message";
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = "<b>Test Mail</b><br>using <b>HTML</b>.";
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                myMail.IsBodyHtml = true;

                mySmtpClient.Send(myMail);
            }

            catch (SmtpException ex)
            {
                throw new ApplicationException
                  ("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("","");
        }
        

        public ActionResult ConfirmRegistration(string nickname, string email, string password)
        {
            Core.FakeService.UserService client = new Core.FakeService.UserService();
            USER newUser = new USER();
            newUser.EMAIL = email;
            newUser.ID_USER = Guid.NewGuid();
            newUser.IS_ENABLED = false;
            newUser.SURNAME = string.Empty;
            newUser.PASSWORD = password;
            newUser.ID_PROFILE = client.GetProfileByCode("USR").Profile.ID_PROFILE;
            newUser.ID_LANGUAGE = client.GetLanguagebyCode("ITA").lingua.ID_LANGUAGE; 
            newUser.NAME = nickname;

            boolView response = client.AddUsers(newUser);

            return RedirectToAction("RegistrationConfirm", "Pages");
        }


        public ActionResult NotFoundError()
        {
            return View();
        }

        public ActionResult InternalServerError()
        {
            return View();
        }

        public ActionResult EmptyPage()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }


    }
}