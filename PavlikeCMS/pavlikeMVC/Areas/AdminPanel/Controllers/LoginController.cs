using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pavlikeMVC.Areas.AdminPanel.Controllers
{
    public class LoginController : Controller
    {
        // GET: AdminPanel/Login
        public ActionResult Index()
        {
            return View();
        }
    }
}