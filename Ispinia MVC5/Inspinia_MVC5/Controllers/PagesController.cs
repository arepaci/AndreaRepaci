﻿
using Core.CustomClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core;
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
        
        public ActionResult ConfirmRegistration(string nickname, string email, string password)
        {
            Core.FakeService.UserService client = new Core.FakeService.UserService();
            USER newUser = new USER();
            newUser.EMAIL = email;
            newUser.ID_USER = Guid.NewGuid();
            newUser.IS_ENABLED = false;
            newUser.PASSWORD = password;
            //newUser.ID_PROFILE = client.GetProfiles().ProfileList.Where()
            //newUser.ID_LANGUAGE = 
            newUser.NAME = nickname;

            boolView response = client.AddUsers(newUser);

            return View();
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