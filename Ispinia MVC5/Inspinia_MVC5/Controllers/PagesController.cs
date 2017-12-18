﻿using AndreaRepaciUI.andreaService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult CheckLogin(string username, string password)
        {
            AndreaRepaciUI.andreaService.UserServiceClient client = new AndreaRepaciUI.andreaService.UserServiceClient();
            boolView response = client.checkLogin(username, password);
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