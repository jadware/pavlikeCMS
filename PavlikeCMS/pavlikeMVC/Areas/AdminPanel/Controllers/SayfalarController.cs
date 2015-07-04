using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pavlikeMVC.Areas.AdminPanel.Controllers
{
    public class SayfalarController : Controller
    {
        // GET: AdminPanel/Sayfalar
        public ActionResult Index()
        {
            return View();
        }
    }
}