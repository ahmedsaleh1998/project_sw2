using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lib_manage_project.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AdminHomePage()
        {
            return View();
        }
    }
}