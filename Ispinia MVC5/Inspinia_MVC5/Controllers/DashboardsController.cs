using Core;
using Core.CustomClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Controllers
{
    public class DashboardsController : Controller
    {

        public ActionResult Dashboard()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Pages");
            }

            return View();
        }

        public ActionResult Dashboard_1()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Pages");
            }
            Core.FakeService.UserService userService = new Core.FakeService.UserService();
            GetUserInfoById_Result userinfo = new GetUserInfoById_Result();
            Session["userInfo"] = userinfo = userService.GetUserInfoById(((UserView)(Session["user"])).User.ID_USER);
            ViewBag.NickName = userinfo.NICKNAME;
            return View();
        }

        public ActionResult Dashboard_2()
        {
            return View();
        }

        public ActionResult Dashboard_3()
        {
            return View();
        }

        public ActionResult Dashboard_4()
        {
            return View();
        }

        public ActionResult Dashboard_4_1()
        {
            return View();
        }

        public ActionResult Dashboard_5()
        {
            return View();
        }

    }
}