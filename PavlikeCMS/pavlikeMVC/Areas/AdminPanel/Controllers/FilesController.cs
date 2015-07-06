using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pavlikeMVC.Areas.AdminPanel.Controllers
{
    public class FilesController : Controller
    {
        // GET: AdminPanel/Files
        public ActionResult Index()
        {
            return View();
        }
    }
}