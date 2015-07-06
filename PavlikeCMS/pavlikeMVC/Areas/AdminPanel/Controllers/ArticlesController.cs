using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pavlikeMVC.Areas.AdminPanel.Controllers
{
    public class ArticlesController : Controller
    {
        // GET: AdminPanel/Articles
        public ActionResult Index()
        {
            return View();
        }
    }
}