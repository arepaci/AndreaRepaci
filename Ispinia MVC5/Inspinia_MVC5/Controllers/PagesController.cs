
using Core.CustomClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
using System.Net.Mail;
using System.Web.Mail;

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
        
        public ActionResult SendMail(string email, string nickname)
        {
            
            try
            {

                SmtpClient mySmtpClient = new SmtpClient("authsmtp.securemail.pro");
                // Set SSL smtp
                mySmtpClient.EnableSsl = true;
                mySmtpClient.Port = 465;
                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                System.Net.NetworkCredential basicAuthenticationInfo = new
                   System.Net.NetworkCredential("info@repaci.eu", "Andreare.76");
                mySmtpClient.Credentials = basicAuthenticationInfo;
                
                // add from,to mailaddresses
                MailAddress from = new MailAddress("info@repaci.eu", "Info ");
                MailAddress to = new MailAddress(email, nickname);
                System.Net.Mail.MailMessage myMail = new System.Net.Mail.MailMessage(from, to);
                

                // add ReplyTo
                //MailAddress replyto = new MailAddress("info@repaci.eu");
                //myMail.ReplyToList.Add("");

                // set subject and encoding
                myMail.Subject = "Conferma Registrazione repaci.eu";
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = "<b>Conferma di registrazione al portale repaci.eu</b><br>using <b>HTML</b>.";
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
            SendMail(email, nickname);
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