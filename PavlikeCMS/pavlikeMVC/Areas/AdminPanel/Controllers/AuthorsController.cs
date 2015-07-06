using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pavlikeMVC.Areas.AdminPanel.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: AdminPanel/Authors
        public ActionResult Index()
        {
            return View();
        }
    }
}